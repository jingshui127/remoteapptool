using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using LockChecker;

namespace RDPSign
{
    public class RDPSign
    {
        public int ErrorNumber = 0;
        public string ErrorString = "";

        public void Main()
        {
            // Empty main method
        }

        /// <summary>
        /// Get all Certificate friendly names
        /// </summary>
        /// <returns>String array of Certificate friendly names</returns>
        public string[] GetCertificateFriendlyName()
        {
            X509Store CertStoreLM = GetCertificateStoreLM();
            X509Store CertStoreCU = GetCertificateStoreCU();

            string[] FriendlyNames = new string[CertStoreLM.Certificates.Count + CertStoreCU.Certificates.Count];
            int Counter = 0;
            foreach (X509Certificate2 Certificate in CertStoreLM.Certificates)
            {
                if (!string.IsNullOrEmpty(Certificate.FriendlyName))
                {
                    FriendlyNames[Counter] = Certificate.FriendlyName;
                    Counter = Counter + 1;
                }
            }
            foreach (X509Certificate2 Certificate in CertStoreCU.Certificates)
            {
                if (!string.IsNullOrEmpty(Certificate.FriendlyName))
                {
                    FriendlyNames[Counter] = Certificate.FriendlyName;
                    Counter = Counter + 1;
                }
            }
            Array.Resize(ref FriendlyNames, Counter);
            return FriendlyNames;
        }

        /// <summary>
        /// Open the Local Machine certificate store and return it to the calling function/sub
        /// </summary>
        /// <returns>Certificate Store</returns>
        public X509Store GetCertificateStoreLM()
        {
            X509Store CertStore = new X509Store(StoreLocation.LocalMachine);
            CertStore.Open(OpenFlags.ReadOnly);
            return CertStore;
        }

        /// <summary>
        /// Open the Current User certificate store and return it to the calling function/sub
        /// </summary>
        /// <returns>Certificate Store</returns>
        public X509Store GetCertificateStoreCU()
        {
            X509Store CertStore = new X509Store(StoreLocation.CurrentUser);
            CertStore.Open(OpenFlags.ReadOnly);
            return CertStore;
        }

        /// <summary>
        /// Given a friendly name, find and return the associated thumbprint
        /// </summary>
        /// <param name="FriendlyName">String of the Friendly Name of a certificate</param>
        /// <returns>String of the thumbprint of the certificate</returns>
        public string GetThumbprint(string FriendlyName)
        {
            string Thumbprint = "";
            X509Store CertStoreLM = GetCertificateStoreLM();
            foreach (X509Certificate2 certificate in CertStoreLM.Certificates)
            {
                if (certificate.FriendlyName == FriendlyName)
                {
                    Thumbprint = certificate.Thumbprint;
                    CertStoreLM.Close();
                    return Thumbprint;
                }
            }
            CertStoreLM.Close();
            X509Store CertStoreCU = GetCertificateStoreCU();
            foreach (X509Certificate2 certificate in CertStoreCU.Certificates)
            {
                if (certificate.FriendlyName == FriendlyName)
                {
                    Thumbprint = certificate.Thumbprint;
                    CertStoreCU.Close();
                    return Thumbprint;
                }
            }
            // We could get here if something went wrong such as Certificate was removed from certificate store after it was loaded into the application
            // return an invalid thumbprint
            return "0000";
        }

        /// <summary>
        /// Sign an RDP file and make a backup of the unsigned one if requested
        /// </summary>
        /// <param name="Thumbprint">Thumbprint used to sign RDP file</param>
        /// <param name="RDPFileLocation">Location of RDP file</param>
        /// <param name="CreateBackup">Boolean indicating if a backup should be created or not</param>
        public void SignRDP(string Thumbprint, string RDPFileLocation, bool CreateBackup)
        {
            if (Thumbprint == "0000")
            {
                //Invalid thumbprint, this should be handled on the application side, but just as a safety, return without doing any work if invalid thumbprint sent
                return;
            }
            if (CreateBackup)
            {
                string BackupFile = Path.GetDirectoryName(RDPFileLocation) + "\\" + Path.GetFileNameWithoutExtension(RDPFileLocation) + "-Unsigned.rdp";
                LockChecker.LockChecker LockCheck = new LockChecker.LockChecker();
                string FileLocked = "";
                bool SkipFile = false;
                FileLocked = LockCheck.CheckLock(BackupFile);
                while (!(FileLocked == "No locks"))
                {
                    if ((MessageBox.Show("文件 " + BackupFile + " 当前被锁定。锁定信息：" + FileLocked + Environment.NewLine + "是否要重试？", "文件已锁定", MessageBoxButtons.YesNo) == DialogResult.Yes))
                    {
                        FileLocked = LockCheck.CheckLock(BackupFile);
                    }
                    else
                    {
                        MessageBox.Show("不会复制以下文件：" + Environment.NewLine + BackupFile);
                        SkipFile = true;
                        FileLocked = "No locks";
                    }
                }
                if (!(SkipFile))
                {
                    File.Copy(RDPFileLocation, BackupFile, true); //backup file with overwrite
                }

            }

            //If we get here, we should be good to run the command to sign the RDP file.

            //Grab the rdpsign.exe location and then verify that it exists

            string Command = GetRdpsignExeLocation();

            if (File.Exists(Command))
            {

                string Arguments = "";
                FileVersionInfo FileVersionInfo = FileVersionInfo.GetVersionInfo(Command);
                // On my windows 10 computer, the argument is /sha256 instead of /sha1.  /sha1 doesn't work.
                // On my windows 10 computer, the Product parts come in at 10.0.18362.1
                // On a Windows Server 2008 R2 server I have access to, the argument is /sha1.
                // On a Windows Server 2008 R2 server I have access to, the Product parts come in at 6.1.7601.17514 which is lower than the windows 10 ones.
                // I do not have other versions of windows to test, so will need external testing for this.
                // Not sure where the version number switches over, but also not sure how to determine which method to use otherwise
                if (FileVersionInfo.ProductMajorPart >= 10)
                {
                    Arguments = " /sha256 " + Thumbprint + " \"" + RDPFileLocation + "\"";

                }
                else
                {
                    Arguments = " /sha1 " + Thumbprint + " \"" + RDPFileLocation + "\"";
                }
                ProcessStartInfo StartInfo = new ProcessStartInfo();
                StartInfo.FileName = Command;
                StartInfo.Arguments = Arguments;
                StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(StartInfo);
            }
            else
            {
                MessageBox.Show("未找到 RDPSign 可执行文件：" + Environment.NewLine + Environment.NewLine + Command, "RDPSign", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Find the full path to rdpsign.exe from a list of possible locations
        /// </summary>
        /// <returns>A path to rdpsign.exe or an empty string</returns>
        public string GetRdpsignExeLocation()
        {
            //Each path to check for rdpsign.exe is added to this array.
            //If it is found in more than one location, the lowest in the list will be selected.
            string[] PossibleRdpsignPaths = {
                Environment.SystemDirectory,
                AppDomain.CurrentDomain.BaseDirectory
            };

            string FinalRdpSignPath = "";

            foreach (string RdpsignPath in PossibleRdpsignPaths)
            {
                if (File.Exists(RdpsignPath + "\\rdpsign.exe"))
                {
                    FinalRdpSignPath = RdpsignPath + "\\rdpsign.exe";
                }
            }

            return FinalRdpSignPath;

        }
    }
}