using System;
using System.IO;
using System.Windows.Forms;
using LockChecker;

namespace RDPFileLib
{
    public class RDPFile
    {
        public int administrative_session = 0;
        public int allow_desktop_composition = 0;
        public int allow_font_smoothing = 0;
        public string alternate_full_address = "";
        public string alternate_shell = "";
        public int audiocapturemode = 0;
        public int audiomode = 0;
        public int audioqualitymode = 0;
        public int authentication_level = 2;
        public int autoreconnect_max_retries = 20;
        public int autoreconnection_enabled = 1;
        public int bandwidthautodetect = 1;
        public int bitmapcachepersistenable = 1;
        public int bitmapcachesize = 1500;
        public string camerastoredirect = "";
        public int compression = 1;
        public int connect_to_console = 0;
        public int connection_type = 2;
        public int desktop_size_id = 0;
        public int desktopheight = 600;
        public int desktopwidth = 800;
        public string devicestoredirect = "";
        public int disable_ctrl_alt_del = 1;
        public int disable_full_window_drag = 1;
        public int disable_menu_anims = 1;
        public int disable_themes = 0;
        public int disable_wallpaper = 1;
        public int disableconnectionsharing = 0;
        public int disableremoteappcapscheck = 0;
        public int displayconnectionbar = 1;
        public string domain = "";
        public string drivestoredirect = "";
        public int enablecredsspsupport = 1;
        public int enablesuperpan = 0;
        public int encode_redirected_video_capture = 1;
        public string full_address = "";
        public int gatewaycredentialssource = 4;
        public string gatewayhostname = "";
        public int gatewayprofileusagemethod = 0;
        public int gatewayusagemethod = 4;
        public int keyboardhook = 2;
        public int negotiate_security_layer = 1;
        public int networkautodetect = 1;
        //public byte[] password_51;
        public int pinconnectionbar = 1;
        public int prompt_for_credentials = 0;
        public int prompt_for_credentials_on_client = 0;
        public int promptcredentialonce = 1;
        public int public_mode = 0;
        public int redirectclipboard = 1;
        public int redirectcomports = 0;
        public int redirectdirectx = 1;
        public int redirectdrives = 0;
        public int redirected_video_capture_encoding_quality = 0;
        public int redirectlocation = 0;
        public int redirectposdevices = 0;
        public int redirectprinters = 1;
        public int redirectsmartcards = 1;
        public int redirectwebauthn = 1;
        public string remoteapplicationcmdline = "";
        public int remoteapplicationexpandcmdline = 1;
        public int remoteapplicationexpandworkingdir = 0;
        public string remoteapplicationfile = "";
        public string remoteapplicationfileextensions = "";
        public string remoteapplicationicon = "";
        public int remoteapplicationmode = 0;
        public string remoteapplicationname = "";
        public string remoteapplicationprogram = "";
        public int screen_mode_id = 2;
        public string selectedmonitors = "";
        public int server_port = 3389;
        public int session_bpp = 32;
        public string shell_working_directory = "";
        public string signscope = "";
        public int smart_sizing = 0;
        public int span_monitors = 0;
        public int superpanaccelerationfactor = 1;
        public string usbdevicestoredirect = "";
        public int use_multimon = 0;
        public string username = "";
        public int videoplaybackmode = 1;
        public string winposstr = "0,3,0,0,800,600";
        public string workspaceid = "";

        public string AdditionalOptions = "";

        public void SaveRDPfile(string FilePath, bool IncludeDefaultSettings = false)
        {
            LockChecker.LockChecker LockCheck = new LockChecker.LockChecker();
            string FileLocked = "";
            bool SkipFile = false;
            FileLocked = LockCheck.CheckLock(FilePath);
            while (!(FileLocked == "No locks"))
            {
                if ((MessageBox.Show("文件 " + FilePath + " 当前被锁定。锁定信息：" + FileLocked + Environment.NewLine + "是否要重试？", "文件已锁定", MessageBoxButtons.YesNo) == DialogResult.Yes))
                {
                    FileLocked = LockCheck.CheckLock(FilePath);
                }
                else
                {
                    MessageBox.Show("不会复制以下文件：" + Environment.NewLine + FilePath);
                    SkipFile = true;
                    FileLocked = "No locks";
                }
            }
            if (!(SkipFile))
            {
                File.WriteAllText(FilePath, GetRDPstring(IncludeDefaultSettings));
            }
        }

        public string GetRDPstring(bool IncludeDefaultSettings = false)
        {
            string RDPstring = "";

            RDPFile DefaultRDP = new RDPFile();

            if (IncludeDefaultSettings || DefaultRDP.administrative_session != administrative_session) RDPstring += "administrative session" + ":" + administrative_session.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + administrative_session.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.allow_desktop_composition != allow_desktop_composition) RDPstring += "allow desktop composition" + ":" + allow_desktop_composition.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + allow_desktop_composition.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.allow_font_smoothing != allow_font_smoothing) RDPstring += "allow font smoothing" + ":" + allow_font_smoothing.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + allow_font_smoothing.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.alternate_full_address != alternate_full_address) RDPstring += "alternate full address" + ":" + alternate_full_address.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + alternate_full_address.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.alternate_shell != alternate_shell) RDPstring += "alternate shell" + ":" + alternate_shell.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + alternate_shell.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.audiocapturemode != audiocapturemode) RDPstring += "audiocapturemode" + ":" + audiocapturemode.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + audiocapturemode.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.audiomode != audiomode) RDPstring += "audiomode" + ":" + audiomode.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + audiomode.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.audioqualitymode != audioqualitymode) RDPstring += "audioqualitymode" + ":" + audioqualitymode.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + audioqualitymode.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.authentication_level != authentication_level) RDPstring += "authentication level" + ":" + authentication_level.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + authentication_level.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.autoreconnect_max_retries != autoreconnect_max_retries) RDPstring += "autoreconnect max retries" + ":" + autoreconnect_max_retries.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + autoreconnect_max_retries.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.autoreconnection_enabled != autoreconnection_enabled) RDPstring += "autoreconnection enabled" + ":" + autoreconnection_enabled.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + autoreconnection_enabled.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.bandwidthautodetect != bandwidthautodetect) RDPstring += "bandwidthautodetect" + ":" + bandwidthautodetect.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + bandwidthautodetect.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.bitmapcachepersistenable != bitmapcachepersistenable) RDPstring += "bitmapcachepersistenable" + ":" + bitmapcachepersistenable.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + bitmapcachepersistenable.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.bitmapcachesize != bitmapcachesize) RDPstring += "bitmapcachesize" + ":" + bitmapcachesize.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + bitmapcachesize.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.camerastoredirect != camerastoredirect) RDPstring += "camerastoredirect" + ":" + camerastoredirect.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + camerastoredirect.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.compression != compression) RDPstring += "compression" + ":" + compression.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + compression.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.connect_to_console != connect_to_console) RDPstring += "connect to console" + ":" + connect_to_console.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + connect_to_console.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.connection_type != connection_type) RDPstring += "connection type" + ":" + connection_type.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + connection_type.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.desktop_size_id != desktop_size_id) RDPstring += "desktop size id" + ":" + desktop_size_id.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + desktop_size_id.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.desktopheight != desktopheight) RDPstring += "desktopheight" + ":" + desktopheight.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + desktopheight.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.desktopwidth != desktopwidth) RDPstring += "desktopwidth" + ":" + desktopwidth.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + desktopwidth.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.devicestoredirect != devicestoredirect) RDPstring += "devicestoredirect" + ":" + devicestoredirect.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + devicestoredirect.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.disable_ctrl_alt_del != disable_ctrl_alt_del) RDPstring += "disable ctrl+alt+del" + ":" + disable_ctrl_alt_del.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + disable_ctrl_alt_del.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.disable_full_window_drag != disable_full_window_drag) RDPstring += "disable full window drag" + ":" + disable_full_window_drag.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + disable_full_window_drag.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.disable_menu_anims != disable_menu_anims) RDPstring += "disable menu anims" + ":" + disable_menu_anims.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + disable_menu_anims.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.disable_themes != disable_themes) RDPstring += "disable themes" + ":" + disable_themes.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + disable_themes.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.disable_wallpaper != disable_wallpaper) RDPstring += "disable wallpaper" + ":" + disable_wallpaper.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + disable_wallpaper.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.disableconnectionsharing != disableconnectionsharing) RDPstring += "disableconnectionsharing" + ":" + disableconnectionsharing.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + disableconnectionsharing.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.disableremoteappcapscheck != disableremoteappcapscheck) RDPstring += "disableremoteappcapscheck" + ":" + disableremoteappcapscheck.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + disableremoteappcapscheck.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.displayconnectionbar != displayconnectionbar) RDPstring += "displayconnectionbar" + ":" + displayconnectionbar.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + displayconnectionbar.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.domain != domain) RDPstring += "domain" + ":" + domain.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + domain.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.drivestoredirect != drivestoredirect) RDPstring += "drivestoredirect" + ":" + drivestoredirect.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + drivestoredirect.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.enablecredsspsupport != enablecredsspsupport) RDPstring += "enablecredsspsupport" + ":" + enablecredsspsupport.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + enablecredsspsupport.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.enablesuperpan != enablesuperpan) RDPstring += "enablesuperpan" + ":" + enablesuperpan.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + enablesuperpan.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.encode_redirected_video_capture != encode_redirected_video_capture) RDPstring += "encode redirected video capture" + ":" + encode_redirected_video_capture.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + encode_redirected_video_capture.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.full_address != full_address) RDPstring += "full address" + ":" + full_address.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + full_address.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.gatewaycredentialssource != gatewaycredentialssource) RDPstring += "gatewaycredentialssource" + ":" + gatewaycredentialssource.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + gatewaycredentialssource.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.gatewayhostname != gatewayhostname) RDPstring += "gatewayhostname" + ":" + gatewayhostname.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + gatewayhostname.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.gatewayprofileusagemethod != gatewayprofileusagemethod) RDPstring += "gatewayprofileusagemethod" + ":" + gatewayprofileusagemethod.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + gatewayprofileusagemethod.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.gatewayusagemethod != gatewayusagemethod) RDPstring += "gatewayusagemethod" + ":" + gatewayusagemethod.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + gatewayusagemethod.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.keyboardhook != keyboardhook) RDPstring += "keyboardhook" + ":" + keyboardhook.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + keyboardhook.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.negotiate_security_layer != negotiate_security_layer) RDPstring += "negotiate security layer" + ":" + negotiate_security_layer.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + negotiate_security_layer.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.networkautodetect != networkautodetect) RDPstring += "networkautodetect" + ":" + networkautodetect.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + networkautodetect.ToString() + Environment.NewLine;
            //if (IncludeDefaultSettings || DefaultRDP.password_51 != password_51) RDPstring += "password 51" + ":" + password_51.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + password_51.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.pinconnectionbar != pinconnectionbar) RDPstring += "pinconnectionbar" + ":" + pinconnectionbar.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + pinconnectionbar.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.prompt_for_credentials != prompt_for_credentials) RDPstring += "prompt for credentials" + ":" + prompt_for_credentials.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + prompt_for_credentials.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.prompt_for_credentials_on_client != prompt_for_credentials_on_client) RDPstring += "prompt for credentials on client" + ":" + prompt_for_credentials_on_client.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + prompt_for_credentials_on_client.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.promptcredentialonce != promptcredentialonce) RDPstring += "promptcredentialonce" + ":" + promptcredentialonce.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + promptcredentialonce.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.public_mode != public_mode) RDPstring += "public mode" + ":" + public_mode.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + public_mode.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.redirectclipboard != redirectclipboard) RDPstring += "redirectclipboard" + ":" + redirectclipboard.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + redirectclipboard.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.redirectcomports != redirectcomports) RDPstring += "redirectcomports" + ":" + redirectcomports.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + redirectcomports.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.redirectdirectx != redirectdirectx) RDPstring += "redirectdirectx" + ":" + redirectdirectx.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + redirectdirectx.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.redirectdrives != redirectdrives) RDPstring += "redirectdrives" + ":" + redirectdrives.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + redirectdrives.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.redirected_video_capture_encoding_quality != redirected_video_capture_encoding_quality) RDPstring += "redirected_video_capture_encoding_quality" + ":" + redirected_video_capture_encoding_quality.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + redirected_video_capture_encoding_quality.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.redirectlocation != redirectlocation) RDPstring += "redirectlocation" + ":" + redirectlocation.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + redirectlocation.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.redirectposdevices != redirectposdevices) RDPstring += "redirectposdevices" + ":" + redirectposdevices.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + redirectposdevices.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.redirectprinters != redirectprinters) RDPstring += "redirectprinters" + ":" + redirectprinters.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + redirectprinters.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.redirectsmartcards != redirectsmartcards) RDPstring += "redirectsmartcards" + ":" + redirectsmartcards.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + redirectsmartcards.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.redirectwebauthn != redirectwebauthn) RDPstring += "redirectwebauthn" + ":" + redirectwebauthn.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + redirectwebauthn.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.remoteapplicationcmdline != remoteapplicationcmdline) RDPstring += "remoteapplicationcmdline" + ":" + remoteapplicationcmdline.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + remoteapplicationcmdline.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.remoteapplicationexpandcmdline != remoteapplicationexpandcmdline) RDPstring += "remoteapplicationexpandcmdline" + ":" + remoteapplicationexpandcmdline.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + remoteapplicationexpandcmdline.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.remoteapplicationexpandworkingdir != remoteapplicationexpandworkingdir) RDPstring += "remoteapplicationexpandworkingdir" + ":" + remoteapplicationexpandworkingdir.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + remoteapplicationexpandworkingdir.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.remoteapplicationfile != remoteapplicationfile) RDPstring += "remoteapplicationfile" + ":" + remoteapplicationfile.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + remoteapplicationfile.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.remoteapplicationfileextensions != remoteapplicationfileextensions) RDPstring += "remoteapplicationfileextensions" + ":" + remoteapplicationfileextensions.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + remoteapplicationfileextensions.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.remoteapplicationicon != remoteapplicationicon) RDPstring += "remoteapplicationicon" + ":" + remoteapplicationicon.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + remoteapplicationicon.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.remoteapplicationmode != remoteapplicationmode) RDPstring += "remoteapplicationmode" + ":" + remoteapplicationmode.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + remoteapplicationmode.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.remoteapplicationname != remoteapplicationname) RDPstring += "remoteapplicationname" + ":" + remoteapplicationname.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + remoteapplicationname.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.remoteapplicationprogram != remoteapplicationprogram) RDPstring += "remoteapplicationprogram" + ":" + remoteapplicationprogram.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + remoteapplicationprogram.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.screen_mode_id != screen_mode_id) RDPstring += "screen mode id" + ":" + screen_mode_id.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + screen_mode_id.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.selectedmonitors != selectedmonitors) RDPstring += "selectedmonitors" + ":" + selectedmonitors.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + selectedmonitors.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.server_port != server_port) RDPstring += "server port" + ":" + server_port.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + server_port.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.session_bpp != session_bpp) RDPstring += "session bpp" + ":" + session_bpp.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + session_bpp.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.shell_working_directory != shell_working_directory) RDPstring += "shell working directory" + ":" + shell_working_directory.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + shell_working_directory.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.signscope != signscope) RDPstring += "signscope" + ":" + signscope.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + signscope.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.smart_sizing != smart_sizing) RDPstring += "smart sizing" + ":" + smart_sizing.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + smart_sizing.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.span_monitors != span_monitors) RDPstring += "span monitors" + ":" + span_monitors.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + span_monitors.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.superpanaccelerationfactor != superpanaccelerationfactor) RDPstring += "superpanaccelerationfactor" + ":" + superpanaccelerationfactor.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + superpanaccelerationfactor.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.usbdevicestoredirect != usbdevicestoredirect) RDPstring += "usbdevicestoredirect" + ":" + usbdevicestoredirect.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + usbdevicestoredirect.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.use_multimon != use_multimon) RDPstring += "use multimon" + ":" + use_multimon.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + use_multimon.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.username != username) RDPstring += "username" + ":" + username.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + username.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.videoplaybackmode != videoplaybackmode) RDPstring += "videoplaybackmode" + ":" + videoplaybackmode.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + videoplaybackmode.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.winposstr != winposstr) RDPstring += "winposstr" + ":" + winposstr.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + winposstr.ToString() + Environment.NewLine;
            if (IncludeDefaultSettings || DefaultRDP.workspaceid != workspaceid) RDPstring += "workspaceid" + ":" + workspaceid.GetType().ToString().Replace("System.", "").ToLower().Substring(0, 1) + ":" + workspaceid.ToString() + Environment.NewLine;

            if (AdditionalOptions != "")
            {
                RDPstring += AdditionalOptions;
            }

            return RDPstring;
        }

        public void LoadRDPfile(string FilePath)
        {
            StreamReader sr = new StreamReader(FilePath);

            while (sr.Peek() != -1)
            {
                string line = sr.ReadLine();
                string[] SplitLine = line.Split(':');

                if (SplitLine.Length >= 3 && !string.IsNullOrEmpty(SplitLine[2]))
                {
                    string value = SplitLine[2];
                    if (SplitLine[0] == "administrative session") administrative_session = int.Parse(value);
                    if (SplitLine[0] == "allow desktop composition") allow_desktop_composition = int.Parse(value);
                    if (SplitLine[0] == "allow font smoothing") allow_font_smoothing = int.Parse(value);
                    if (SplitLine[0] == "alternate full address") alternate_full_address = value;
                    if (SplitLine[0] == "alternate shell") alternate_shell = value;
                    if (SplitLine[0] == "audiocapturemode") audiocapturemode = int.Parse(value);
                    if (SplitLine[0] == "audiomode") audiomode = int.Parse(value);
                    if (SplitLine[0] == "audioqualitymode") audioqualitymode = int.Parse(value);
                    if (SplitLine[0] == "authentication level") authentication_level = int.Parse(value);
                    if (SplitLine[0] == "autoreconnect max retries") autoreconnect_max_retries = int.Parse(value);
                    if (SplitLine[0] == "autoreconnection enabled") autoreconnection_enabled = int.Parse(value);
                    if (SplitLine[0] == "bandwidthautodetect") bandwidthautodetect = int.Parse(value);
                    if (SplitLine[0] == "bitmapcachepersistenable") bitmapcachepersistenable = int.Parse(value);
                    if (SplitLine[0] == "bitmapcachesize") bitmapcachesize = int.Parse(value);
                    if (SplitLine[0] == "camerastoredirect") camerastoredirect = value;
                    if (SplitLine[0] == "compression") compression = int.Parse(value);
                    if (SplitLine[0] == "connect to console") connect_to_console = int.Parse(value);
                    if (SplitLine[0] == "connection type") connection_type = int.Parse(value);
                    if (SplitLine[0] == "desktop size id") desktop_size_id = int.Parse(value);
                    if (SplitLine[0] == "desktopheight") desktopheight = int.Parse(value);
                    if (SplitLine[0] == "desktopwidth") desktopwidth = int.Parse(value);
                    if (SplitLine[0] == "devicestoredirect") devicestoredirect = value;
                    if (SplitLine[0] == "disable ctrl+alt+del") disable_ctrl_alt_del = int.Parse(value);
                    if (SplitLine[0] == "disable full window drag") disable_full_window_drag = int.Parse(value);
                    if (SplitLine[0] == "disable menu anims") disable_menu_anims = int.Parse(value);
                    if (SplitLine[0] == "disable themes") disable_themes = int.Parse(value);
                    if (SplitLine[0] == "disable wallpaper") disable_wallpaper = int.Parse(value);
                    if (SplitLine[0] == "disableconnectionsharing") disableconnectionsharing = int.Parse(value);
                    if (SplitLine[0] == "disableremoteappcapscheck") disableremoteappcapscheck = int.Parse(value);
                    if (SplitLine[0] == "displayconnectionbar") displayconnectionbar = int.Parse(value);
                    if (SplitLine[0] == "domain") domain = value;
                    if (SplitLine[0] == "drivestoredirect") drivestoredirect = value;
                    if (SplitLine[0] == "enablecredsspsupport") enablecredsspsupport = int.Parse(value);
                    if (SplitLine[0] == "enablesuperpan") enablesuperpan = int.Parse(value);
                    if (SplitLine[0] == "encode redirected video capture") encode_redirected_video_capture = int.Parse(value);
                    if (SplitLine[0] == "full address") full_address = value;
                    if (SplitLine[0] == "gatewaycredentialssource") gatewaycredentialssource = int.Parse(value);
                    if (SplitLine[0] == "gatewayhostname") gatewayhostname = value;
                    if (SplitLine[0] == "gatewayprofileusagemethod") gatewayprofileusagemethod = int.Parse(value);
                    if (SplitLine[0] == "gatewayusagemethod") gatewayusagemethod = int.Parse(value);
                    if (SplitLine[0] == "keyboardhook") keyboardhook = int.Parse(value);
                    if (SplitLine[0] == "negotiate security layer") negotiate_security_layer = int.Parse(value);
                    if (SplitLine[0] == "networkautodetect") networkautodetect = int.Parse(value);
                    //if (SplitLine[0] == "password 51") password_51 = value;
                    if (SplitLine[0] == "pinconnectionbar") pinconnectionbar = int.Parse(value);
                    if (SplitLine[0] == "prompt for credentials") prompt_for_credentials = int.Parse(value);
                    if (SplitLine[0] == "prompt for credentials on client") prompt_for_credentials_on_client = int.Parse(value);
                    if (SplitLine[0] == "promptcredentialonce") promptcredentialonce = int.Parse(value);
                    if (SplitLine[0] == "public mode") public_mode = int.Parse(value);
                    if (SplitLine[0] == "redirectclipboard") redirectclipboard = int.Parse(value);
                    if (SplitLine[0] == "redirectcomports") redirectcomports = int.Parse(value);
                    if (SplitLine[0] == "redirectdirectx") redirectdirectx = int.Parse(value);
                    if (SplitLine[0] == "redirectdrives") redirectdrives = int.Parse(value);
                    if (SplitLine[0] == "redirected video capture encoding quality") redirected_video_capture_encoding_quality = int.Parse(value);
                    if (SplitLine[0] == "redirectlocation") redirectlocation = int.Parse(value);
                    if (SplitLine[0] == "redirectposdevices") redirectposdevices = int.Parse(value);
                    if (SplitLine[0] == "redirectprinters") redirectprinters = int.Parse(value);
                    if (SplitLine[0] == "redirectsmartcards") redirectsmartcards = int.Parse(value);
                    if (SplitLine[0] == "redirectwebauthn") redirectwebauthn = int.Parse(value);
                    if (SplitLine[0] == "remoteapplicationcmdline") remoteapplicationcmdline = value;
                    if (SplitLine[0] == "remoteapplicationexpandcmdline") remoteapplicationexpandcmdline = int.Parse(value);
                    if (SplitLine[0] == "remoteapplicationexpandworkingdir") remoteapplicationexpandworkingdir = int.Parse(value);
                    if (SplitLine[0] == "remoteapplicationfile") remoteapplicationfile = value;
                    if (SplitLine[0] == "remoteapplicationfileextensions") remoteapplicationfileextensions = value;
                    if (SplitLine[0] == "remoteapplicationicon") remoteapplicationicon = value;
                    if (SplitLine[0] == "remoteapplicationmode") remoteapplicationmode = int.Parse(value);
                    if (SplitLine[0] == "remoteapplicationname") remoteapplicationname = value;
                    if (SplitLine[0] == "remoteapplicationprogram") remoteapplicationprogram = value;
                    if (SplitLine[0] == "screen mode id") screen_mode_id = int.Parse(value);
                    if (SplitLine[0] == "selectedmonitors") selectedmonitors = value;
                    if (SplitLine[0] == "server port") server_port = int.Parse(value);
                    if (SplitLine[0] == "session bpp") session_bpp = int.Parse(value);
                    if (SplitLine[0] == "shell working directory") shell_working_directory = value;
                    if (SplitLine[0] == "signscope") signscope = value;
                    if (SplitLine[0] == "smart sizing") smart_sizing = int.Parse(value);
                    if (SplitLine[0] == "span monitors") span_monitors = int.Parse(value);
                    if (SplitLine[0] == "superpanaccelerationfactor") superpanaccelerationfactor = int.Parse(value);
                    if (SplitLine[0] == "usbdevicestoredirect") usbdevicestoredirect = value;
                    if (SplitLine[0] == "use multimon") use_multimon = int.Parse(value);
                    if (SplitLine[0] == "username") username = value;
                    if (SplitLine[0] == "videoplaybackmode") videoplaybackmode = int.Parse(value);
                    if (SplitLine[0] == "winposstr") winposstr = value;
                    if (SplitLine[0] == "workspaceid") workspaceid = value;
                }
            }
            sr.Close();
        }
    }
}