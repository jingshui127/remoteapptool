using System.Collections.Generic;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RemoteAppTool
{
    public partial class RDPOptionsWindow : Form
    {
        // Array to store the all RDP options
        // Each row represents an RDP option with its name, type, default value, and description
        private string[,] optionsList = {
            {"administrative_session", "administrative session", "i", "0", "连接到远程计算机的管理员会话。\n\n0 - 不使用管理员会话。\n1 - 连接到管理员会话。", ""},
            {"allow_desktop_composition", "allow desktop composition", "i", "0", "确定登录到远程计算机时是否允许桌面组合（Aero所需）。\n\n0 - 在远程会话中禁用桌面组合。\n1 - 允许桌面组合。", ""},
            {"allow_font_smoothing", "allow font smoothing", "i", "0", "确定是否可以在远程会话中使用字体平滑。\n\n0 - 在远程会话中禁用字体平滑。\n1 - 允许字体平滑。", ""},
            {"audiocapturemode", "audiocapturemode", "i", "0", "确定连接到远程计算机时如何处理本地计算机上捕获（录制）的声音。\n\n0 - 不从本地计算机捕获音频。\n1 - 从本地计算机捕获音频并发送到远程计算机。", ""},
            {"audiomode", "audiomode", "i", "0", "确定连接到远程计算机时如何处理远程计算机上的声音。\n\n0 - 在本地计算机上播放声音。\n1 - 在远程计算机上播放声音。\n2 - 不播放声音。", ""},
            {"audioqualitymode", "audioqualitymode", "i", "0", "确定远程会话中播放的音频质量。\n\n0 - 根据可用带宽动态调整音频质量。\n1 - 始终使用中等音频质量。\n2 - 始终使用未压缩的音频质量。", ""},
            {"authentication_level", "authentication level", "i", "2", "确定服务器身份验证失败时应发生的情况。\n\n0 - 如果服务器身份验证失败，则在不发出警告的情况下连接。\n1 - 如果服务器身份验证失败，则不连接。\n2 - 如果服务器身份验证失败，则显示警告并允许用户选择是否连接。\n3 - 不需要服务器身份验证。", ""},
            {"autoreconnect_max_retries", "autoreconnect max retries", "i", "20", "确定连接断开时客户端计算机尝试重新连接到远程计算机的最大次数。\n注意：远程桌面可以处理的最大值是200。", ""},
            {"autoreconnection_enabled", "autoreconnection enabled", "i", "1", "确定连接断开时客户端计算机是否自动尝试重新连接到远程计算机。\n\n0 - 不尝试重新连接。\n1 - 尝试重新连接。", ""},
            {"bandwidthautodetect", "bandwidthautodetect", "i", "1", "启用网络类型自动检测选项。与networkautodetect结合使用。另请参见连接类型。\n\n0 - 不启用自动网络检测选项。\n1 - 启用自动网络检测选项。", ""},
            {"bitmapcachepersistenable", "bitmapcachepersistenable", "i", "1", "确定位图是否缓存在本地计算机（基于磁盘的缓存）上。位图缓存可以提高远程会话的性能。\n\n0 - 不缓存位图。\n1 - 缓存位图。", ""},
            {"bitmapcachesize", "bitmapcachesize", "i", "1500", "指定基于内存的位图缓存的大小（以千字节为单位）。最大值为32000。", ""},
            {"camerastoredirect", "camerastoredirect", "s", "", "配置要重定向的摄像头。此设置使用分号分隔的KSCATEGORY_VIDEO_CAMERA接口列表，这些接口是为重定向而启用的摄像头。", ""},
            {"compression", "compression", "i", "1", "确定连接是否应使用批量压缩。\n\n0 - 不使用批量压缩。\n1 - 使用批量压缩。", ""},
            {"connect_to_console", "connect to console", "i", "0", "连接到远程计算机的控制台会话。\n\n0 - 连接到普通会话。\n1 - 连接到控制台屏幕。", "1"},
            {"connection_type", "connection type", "i", "2", "指定远程桌面会话的预定义性能设置。\n\n1 - 调制解调器（56 Kbps）。\n2 - 低速宽带（256 Kbps - 2 Mbps）。\n3 - 卫星（2 Mbps - 16 Mbps，高延迟）。\n4 - 高速宽带（2 Mbps - 10 Mbps）。\n5 - 广域网（10 Mbps或更高，高延迟）。\n6 - 局域网（10 Mbps或更高）。\n7 - 自动带宽检测。需要bandwidthautodetect。\n\n单独使用时，此设置无效。在RDC GUI中选择时，此选项会更改几个与性能相关的设置（主题、动画、字体平滑等）。这些单独的设置总是优先于连接类型设置。", ""},
            {"desktop_size_id", "desktop size id", "i", "0", "指定远程会话桌面的预定义尺寸。\n\n0 - 640x480。\n1 - 800x600。\n2 - 1024x768。\n3 - 1280x1024。\n4 - 1600x1200。\n\n当已经指定了/w和/h或desktopwidth和desktopheight时，此设置将被忽略。", ""},
            {"desktopheight", "desktopheight", "i", "600", "远程会话桌面的高度（以像素为单位）。", ""},
            {"desktopscalefactor", "desktopscalefactor", "i", "", "指定远程会话的缩放因子，使内容显示更大。\n\n支持的值：\n来自以下列表的数值：100, 125, 150, 175, 200, 250, 300, 400, 500\n\n注意：desktopscalefactor属性已被弃用，很快将不可用。", ""},
            {"desktopwidth", "desktopwidth", "i", "800", "远程会话桌面的宽度（以像素为单位）。", ""},
            {"devicestoredirect", "devicestoredirect", "s", "", "确定客户端计算机上的哪些受支持的即插即用设备将被重定向并在远程会话中可用。\n\n未指定值 - 不重定向任何受支持的即插即用设备。\n* - 重定向所有受支持的即插即用设备，包括稍后连接的设备。\nDynamicDevices - 重定向稍后连接的任何受支持的即插即用设备。\n一个或多个即插即用设备的硬件ID - 重定向指定的受支持的即插即用设备。", ""},
            {"disable_ctrl+alt+del", "disable ctrl+alt+del", "i", "1", "确定连接到远程计算机后输入凭据之前是否必须按CTRL+ALT+DELETE。\n\n0 - 登录前需要CTRL+ALT+DELETE。\n1 - 不需要CTRL+ALT+DELETE。您可以立即登录。\n\n注意：禁用时，此设置还会延迟自动登录，直到用户按下CTRL+ALT+DELETE。", ""},
            {"disable_full_window_drag", "disable full window drag", "i", "1", "确定拖动窗口到新位置时是否显示窗口内容。\n\n0 - 拖动时显示窗口内容。\n1 - 拖动时显示窗口轮廓。", ""},
            {"disable_menu_anims", "disable menu anims", "i", "1", "确定远程会话中菜单和窗口是否可以显示动画效果。\n\n0 - 允许菜单和窗口动画。\n1 - 无菜单和窗口动画。", ""},
            {"disable_themes", "disable themes", "i", "0", "确定登录到远程计算机时是否允许主题。\n\n0 - 允许主题。\n1 - 在远程会话中禁用主题。", ""},
            {"disable_wallpaper", "disable wallpaper", "i", "1", "确定远程会话中是否显示桌面背景。\n\n0 - 显示壁纸。\n1 - 不显示任何壁纸。", ""},
            {"disableconnectionsharing", "disableconnectionsharing", "i", "0", "确定每次使用相同凭据启动远程应用到同一计算机时是否启动新的终端服务器会话。\n\n0 - 不启动新会话。共享用户的当前活动会话。\n1 - 为远程应用启动新的登录会话。", ""},
            {"disableremoteappcapscheck", "disableremoteappcapscheck", "i", "0", "指定远程桌面客户端是否应检查远程计算机的远程应用功能。\n0 - 登录前检查远程计算机的远程应用功能。\n1 - 不检查远程计算机的远程应用功能。注意：连接到配置了远程应用的Windows XP SP3、Vista或7计算机时，必须将此设置设为1。", ""},
            {"displayconnectionbar", "displayconnectionbar", "i", "1", "确定全屏模式时是否显示连接栏。\n\n0 - 不显示连接栏。\n1 - 显示连接栏。", ""},
            {"domain", "domain", "s", "", "指定用户的域名。", ""},
            {"drivestoredirect", "drivestoredirect", "s", "", "确定客户端计算机上的哪些本地磁盘驱动器将被重定向并在远程会话中可用。\n\n未指定值 - 不重定向任何驱动器。\n* - 重定向所有磁盘驱动器，包括稍后连接的驱动器。\nDynamicDrives - 重定向稍后连接的任何驱动器。\n一个或多个驱动器的驱动器和标签 - 重定向指定的驱动器。", ""},
            {"dynamic_resolution", "dynamic resolution", "i", "1", "确定本地窗口调整大小时远程会话的分辨率是否自动更新。\n\n0 - 会话分辨率在会话期间保持静态。\n1 - 本地窗口调整大小时会话分辨率更新。", ""},
            {"enablecredsspsupport", "enablecredsspsupport", "i", "1", "确定远程桌面在可用时是否使用CredSSP进行身份验证。\n\n0 - 即使操作系统支持也不使用CredSSP。\n1 - 如果操作系统支持则使用CredSSP。", ""},
            {"enablerdsaadauth", "enablerdsaadauth", "i", "0", "确定客户端是否使用Microsoft Entra ID对远程PC进行身份验证。与Azure虚拟桌面一起使用时，这提供了单点登录体验。此属性替换了targetisaadjoined属性。\n\n0 - 连接不会使用Microsoft Entra身份验证，即使远程PC支持。\n1 - 如果远程PC支持，连接将使用Microsoft Entra身份验证。", ""},
            {"enablesuperpan", "enablesuperpan", "i", "0", "确定是启用还是禁用SuperPan。SuperPan允许用户在全屏模式下导航远程桌面，而无需滚动条，当远程桌面的尺寸大于当前客户端窗口的尺寸时。用户可以指向窗口边框，桌面视图将自动向该方向滚动。\n\n0 - 不使用SuperPan。远程会话窗口调整为客户端窗口大小。\n1 - 启用SuperPan。远程会话窗口调整为通过/w和/h或desktopwidth和desktopheight指定的尺寸。", ""},
            {"encode_redirected_video_capture", "encode redirected video capture", "i", "1", "启用或禁用重定向视频编码。\n\n0 - 禁用重定向视频编码。\n\n1 - 启用重定向视频编码。", ""},
            {"gatewaycredentialssource", "gatewaycredentialssource", "i", "4", "指定应用于验证与RD网关连接的凭据。\n\n0 - 要求输入密码（NTLM）。\n1 - 使用智能卡。\n4 - 允许用户稍后选择。", ""},
            {"kdcproxyname", "kdcproxyname", "s", "", "指定KDC代理的完全限定域名。", ""},
            {"keyboardhook", "keyboardhook", "i", "2", "确定连接到远程计算机时如何应用Windows键组合。\n\n0 - Windows键组合应用于本地计算机。\n1 - Windows键组合应用于远程计算机。\n2 - 仅在全屏模式下应用Windows键组合。", ""},
            {"maximizetocurrentdisplays", "maximizetocurrentdisplays", "i", "0", "确定最大化时远程会话使用哪个显示器进行全屏显示。需要将use multimon设置为1。仅在Windows应用和Windows远程桌面应用中可用。\n\n0 - 会话在最大化时全屏显示在最初选择的显示器上。\n1 - 会话在最大化时动态全屏显示在会话窗口跨越的显示器上。", ""},
            {"negotiate_security_layer", "negotiate security layer", "i", "1", "确定是否协商安全级别。\n\n0 - 不启用安全层协商，会话使用安全套接字层（SSL）启动。\n1 - 启用安全层协商，会话使用x.224加密启动。", ""},
            {"networkautodetect", "networkautodetect", "i", "1", "确定是否使用自动网络带宽检测。需要设置bandwidthautodetect选项，并与连接类型7相关联。\n\n0 - 使用自动网络带宽检测。\n1 - 不使用自动网络带宽检测。", ""},
            {"pinconnectionbar", "pinconnectionbar", "i", "1", "确定全屏模式下连接时连接栏是否应固定在远程会话的顶部。\n\n0 - 连接栏不应固定在远程会话的顶部。\n1 - 连接栏应固定在远程会话的顶部。", ""},
            {"prompt_for_credentials", "prompt for credentials", "i", "0", "确定连接到已保存凭据的远程计算机时，远程桌面连接是否会提示输入凭据。\n\n0 - 远程桌面将使用保存的凭据，不会提示输入凭据。\n1 - 远程桌面将提示输入凭据。", ""},
            {"prompt_for_credentials_on_client", "prompt for credentials on client", "i", "0", "确定连接到不支持服务器身份验证的服务器时，远程桌面连接是否会提示输入凭据。\n\n0 - 远程桌面不会提示输入凭据。\n1 - 远程桌面将提示输入凭据。", ""},
            {"promptcredentialonce", "promptcredentialonce", "i", "1", "通过RD网关连接时，确定RDC是否应为RD网关和远程计算机使用相同的凭据。\n\n0 - 远程桌面不会使用相同的凭据。\n1 - 远程桌面将为RD网关和远程计算机使用相同的凭据。", ""},
            {"public_mode", "public mode", "i", "0", "确定远程桌面连接是否以公共模式启动。\n\n0 - 远程桌面不会以公共模式启动。\n1 - 远程桌面将以公共模式启动，并且不会在本地计算机上保存任何用户数据（凭据、位图缓存、MRU）。", ""},
            {"redirectclipboard", "redirectclipboard", "i", "1", "确定客户端计算机上的剪贴板是否会被重定向并在远程会话中可用，反之亦然。\n\n0 - 不重定向剪贴板。\n1 - 重定向剪贴板。", ""},
            {"redirectcomports", "redirectcomports", "i", "0", "确定客户端计算机上的COM（串行）端口是否会被重定向并在远程会话中可用。\n\n0 - 本地计算机上的COM端口在远程会话中不可用。\n1 - 本地计算机上的COM端口在远程会话中可用。", ""},
            {"redirectdirectx", "redirectdirectx", "i", "1", "确定远程会话中是否启用DirectX。\n\n0 - 不启用DirectX渲染。\n1 - 在远程会话中启用DirectX渲染。", ""},
            {"redirectdrives", "redirectdrives", "i", "0", "确定客户端计算机上的本地磁盘驱动器是否会被重定向并在远程会话中可用。\n\n0 - 本地计算机上的驱动器在远程会话中不可用。\n1 - 本地计算机上的驱动器在远程会话中可用。\n\n注意：从RDC 6.0开始，此设置被drivestoredirect替换。", "1"},
            {"redirected_video_capture_encoding_quality", "redirected video capture encoding quality", "i", "0", "控制编码视频的质量。\n\n0 - 高压缩视频。当有很多运动时，质量可能会受到影响。\n1 - 中等压缩。\n2 - 低压缩视频，高质量画面。", ""},
            {"redirectlocation", "redirectlocation", "i", "0", "确定本地设备的位置是否会被重定向并在远程会话中可用。\n\n0 - 远程会话使用远程计算机的位置。\n1 - 远程会话使用本地设备的位置。", ""},
            {"redirectposdevices", "redirectposdevices", "i", "0", "确定连接到客户端计算机的Microsoft Point of Service (POS) for .NET设备是否会被重定向并在远程会话中可用。\n\n0 - 本地计算机上的POS设备在远程会话中不可用。\n1 - 本地计算机上的POS设备在远程会话中可用。", ""},
            {"redirectprinters", "redirectprinters", "i", "1", "确定客户端计算机上配置的打印机是否会被重定向并在远程会话中可用。\n\n0 - 本地计算机上的打印机在远程会话中不可用。\n1 - 本地计算机上的打印机在远程会话中可用。", ""},
            {"redirectsmartcards", "redirectsmartcards", "i", "1", "确定客户端计算机上的智能卡设备是否会被重定向并在远程会话中可用。\n\n0 - 本地计算机上的智能卡设备在远程会话中不可用。\n1 - 本地计算机上的智能卡设备在远程会话中可用。", ""},
            {"redirectwebauthn", "redirectwebauthn", "i", "1", "确定远程计算机上的WebAuthn请求是否会被重定向到本地计算机，允许使用本地验证器（如Windows Hello for Business和安全密钥）。\n\n0 - 远程会话中的WebAuthn请求不会发送到本地计算机进行身份验证，必须在远程会话中完成。\n1 - 远程会话中的WebAuthn请求会发送到本地计算机进行身份验证。", ""},
            {"remoteapplicationcmdline", "remoteapplicationcmdline", "s", "", "远程应用的可选命令行参数。", ""},
            {"remoteapplicationexpandworkingdir", "remoteapplicationexpandworkingdir", "i", "0", "确定远程应用工作目录参数中包含的环境变量应在本地还是远程展开。\n\n0 - 环境变量应展开为本地计算机的值。\n1 - 环境变量应在远程计算机上展开为远程计算机的值。\n\n注意：远程应用工作目录通过shell工作目录参数指定。", ""},
            {"remoteapplicationicon", "remoteapplicationicon", "s", "", "指定在启动远程应用时在远程桌面界面中显示的图标文件名。默认情况下，RDC将显示标准的远程桌面图标。\n\n注意：仅支持.ico文件。", ""},
            {"screen_mode_id", "screen mode id", "i", "2", "确定连接到远程计算机时远程会话窗口是否全屏显示。\n\n1 - 远程会话将在窗口中显示。\n2 - 远程会话将全屏显示。", ""},
            {"selectedmonitors", "selectedmonitors", "s", "", "指定用于远程会话的本地显示器。所选显示器必须是连续的。需要将use multimon设置为1。\n\n以逗号分隔的机器特定显示ID列表。您可以通过调用mstsc.exe /l来检索ID。列表中的第一个ID将被设置为会话中的主显示器。默认为所有显示器。", ""},
            {"session_bpp", "session bpp", "i", "32", "确定连接时远程计算机上的颜色深度（以位为单位）。\n\n8 - 256色（8位）。\n15 - 高彩色（15位）。\n16 - 高彩色（16位）。\n24 - 真彩色（24位）。\n32 - 最高质量（32位）。", ""},
            {"shell_working_directory", "shell working directory", "s", "", "指定在远程计算机上使用的备用shell的工作目录。", ""},
            {"signscope", "signscope", "s", "", "以逗号分隔的.rdp文件设置列表，在使用.rdp文件签名时生成签名。", ""},
            {"singlemoninwindowedmode", "singlemoninwindowedmode", "i", "0", "确定多显示器远程会话在退出全屏时是否自动切换到单显示器。需要将use multimon设置为1。仅在Windows应用和Windows远程桌面应用中可用。\n\n0 - 远程会话在退出全屏时保留所有显示器。\n1 - 远程会话在退出全屏时切换到单显示器。", ""},
            {"smart_sizing", "smart sizing", "i", "0", "确定客户端计算机在调整窗口大小时是否应缩放远程计算机上的内容以适应客户端计算机的窗口大小。\n\n0 - 调整客户端窗口大小时不会缩放显示。\n1 - 调整客户端窗口大小时会缩放显示。", ""},
            {"span_monitors", "span monitors", "i", "0", "确定连接到远程计算机时远程会话窗口是否跨越多个监视器。\n\n0 - 不启用监视器跨越。\n1 - 启用监视器跨越。\n\n注意：使用远程桌面连接7（Windows 7/2008）时，建议使用use multimon设置。", ""},
            {"superpanaccelerationfactor", "superpanaccelerationfactor", "i", "1", "指定在SuperPan模式下，客户端每移动一个像素时屏幕视图在给定方向上滚动的像素数", ""},
            {"targetisaadjoined", "targetisaadjoined", "i", "0", "允许使用用户名和密码连接到Microsoft Entra加入的会话主机。此属性仅适用于非Windows客户端和未加入Microsoft Entra的本地Windows设备。\n\n0 - 连接到Microsoft Entra加入的会话主机将成功用于满足要求的Windows设备，但其他连接将失败。\n1 - 连接到Microsoft Entra加入的主机会成功，但限制为在连接到会话主机时输入用户名和密码凭据。\n\n注意：此属性正在被enablerdsaadauth替换。", ""},
            {"usbdevicestoredirect", "usbdevicestoredirect", "s", "", "确定连接到支持RemoteFX USB重定向的远程会话时，客户端计算机上的哪些受支持的RemoteFX USB设备将被重定向并在远程会话中可用。\n\n未指定值 - 不重定向任何受支持的RemoteFX USB设备。\n* - 重定向所有支持RemoteFX USB重定向且未被高级重定向机制重定向的设备。\n{设备安装类GUID} - 重定向指定设备安装类的所有受支持的RemoteFX USB设备。\nUSB\\实例ID - 重定向由给定实例ID指定的受支持的RemoteFX USB设备。\n-USB\\实例ID - 即使设备在被重定向的设备安装类中，也不重定向由给定实例ID指定的受支持的RemoteFX USB设备。", ""},
            {"use_multimon", "use multimon", "i", "0", "确定会话在连接到远程计算机时是否应使用真正的多监视器支持。\n\n0 - 不启用多监视器支持。\n1 - 启用多监视器支持。", ""},
            {"username", "username", "s", "", "指定将用于登录到远程计算机的用户帐户名称。", ""},
            {"videoplaybackmode", "videoplaybackmode", "i", "1", "确定RDC是否将使用RDP高效多媒体流进行视频播放。\n\n0 - 不使用RDP高效多媒体流进行视频播放。\n1 - 在可能时使用RDP高效多媒体流进行视频播放。", ""},
            {"winposstr", "winposstr", "s", "0,3,0,0,800,600", "指定客户端计算机上会话窗口的位置和尺寸。", ""},
            {"workspaceid", "workspaceid", "s", "", "此设置定义与此设置包含的.rdp文件关联的RemoteApp和桌面ID。\n\n否", ""}
        };

        // Array to store recommended default options
        public string[,] RecommendedDefaultOptions = {
            {"disableremoteappcapscheck", "disableremoteappcapscheck", "i", "1"},
            {"drivestoredirect", "drivestoredirect", "s", "*"},
            {"prompt_for_credentials", "prompt for credentials", "i", "1"},
            {"promptcredentialonce", "promptcredentialonce", "i", "0"},
            {"redirectcomports", "redirectcomports", "i", "1"},
            {"span_monitors", "span monitors", "i", "1"},
            {"use_multimon", "use multimon", "i", "1"}
        };

        // Array to store changed options during editing
        private string[,] changedOptions;

        // Index of the currently selected row in the OptionsListBox
        private int selectedRow = 0;

        public RDPOptionsWindow()
        {
            InitializeComponent();
            
            // 手动初始化ImageList，使用系统图标作为临时解决方案
            InitializeImageList();
            
            // 根据用户偏好添加完整的Tooltip功能，背景色为浅黄色
            SetToolTips();
        }
        
        /// <summary>
        /// 为所有控件设置Tooltip，使用用户偏好的浅黄色背景
        /// </summary>
        private void SetToolTips()
        {
            var toolTip = new ToolTip();
            toolTip.BackColor = Color.LightYellow;  // 用户偏好的浅黄色背景
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;

            // 主要控件
            toolTip.SetToolTip(this.OptionsListBox, "选择要配置的RDP选项\n包含所有可用的远程桌面连接配置参数");
            toolTip.SetToolTip(this.DescriptionTextBox, "显示所选RDP选项的详细说明\n包含参数的功能、可用值和默认设置");
            toolTip.SetToolTip(this.ValueTextBox, "输入或编辑所选RDP选项的值\n可以是数字或字符串，根据选项类型决定");
            toolTip.SetToolTip(this.ChangedOptionsListView, "已修改的RDP选项列表\n显示所有与默认值不同的选项\n双击可快速切换到该选项");
            
            // 操作按钮
            toolTip.SetToolTip(this.SaveButton, "保存所有更改并关闭窗口\n应用当前的RDP选项配置");
            toolTip.SetToolTip(this.ResetButton, "重置所有选项为默认值\n清除所有自定义配置，恢复为系统默认设置");
            toolTip.SetToolTip(this.DefaultsButton, "应用推荐的默认配置\n设置为经过优化的常用RemoteApp连接配置");
            toolTip.SetToolTip(this.ResetValueButton, "重置当前选项为默认值\n仅重置当前选中的RDP选项，不影响其他选项");
        }

        // Copy the original options to the changedOptions array
        private void CopyOptions()
        {
            changedOptions = new string[optionsList.GetLength(0), optionsList.GetLength(1)];
            Array.Copy(optionsList, changedOptions, optionsList.Length);
        }

        // Main function that prepares and opens the window (to be called from elsewhere)
        public string[,] EditAdditionalOptions(string[,] additionalOptions)
        {
            // Copy options, load additional options, and update the changed options
            CopyOptions();
            LoadAdditionalOptions(additionalOptions);
            UpdateChangedOptions();

            // Load options into the OptionsListBox
            OptionsListBox.Items.Clear();
            for (int row = 0; row < optionsList.GetLength(0); row++)
            {
                OptionsListBox.Items.Add(optionsList[row, 1]);
            }

            // Set the selected item in OptionsListBox and load the selected option
            OptionsListBox.SelectedIndex = selectedRow;
            LoadSelected();

            // Show the form
            ShowDialog();

            // Export saved options and return the result
            string[,] savedOptions = ExportSavedOptionsAsArray();
            Dispose();
            return savedOptions;
        }

        // Load additional options and update the changed options array
        private void LoadAdditionalOptions(string[,] additionalOptions)
        {
            if (additionalOptions.Length > 1)
            {
                for (int row = 0; row < optionsList.GetLength(0); row++)
                {
                    for (int additionalOptionRow = 0; additionalOptionRow < additionalOptions.GetLength(0); additionalOptionRow++)
                    {
                        if (optionsList[row, 0] == additionalOptions[additionalOptionRow, 0])
                        {
                            changedOptions[row, 3] = additionalOptions[additionalOptionRow, 3];
                        }
                    }
                }
            }
        }

        // Handle the selection change in OptionsListBox
        private void OptionsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OptionsListBox.SelectedItems.Count == 1)
            {
                selectedRow = OptionsListBox.SelectedIndex;
                LoadSelected();
            }
        }

        // Load the details of the selected option into the description and value textboxes
        private void LoadSelected()
        {
            string descriptionText = "# " + optionsList[selectedRow, 1] + Environment.NewLine + Environment.NewLine;
            descriptionText = descriptionText + optionsList[selectedRow, 4].Replace("\\n", Environment.NewLine);
            string valueText = changedOptions[selectedRow, 3];

            if (!string.IsNullOrEmpty(optionsList[selectedRow, 3]))
            {
                descriptionText = descriptionText + Environment.NewLine + Environment.NewLine + "Default: " + optionsList[selectedRow, 3];
            }

            DescriptionTextBox.Text = descriptionText;
            ValueTextBox.Text = valueText;
        }

        // Handle the change in the value textbox
        private void ValueTextBox_TextChanged(object sender, EventArgs e)
        {
            if (changedOptions[selectedRow, 3] != ValueTextBox.Text)
            {
                changedOptions[selectedRow, 3] = ValueTextBox.Text;
                UpdateChangedOptions();
            }
        }

        // Update the ChangedOptionsListView with any changes
        private void UpdateChangedOptions()
        {
            ChangedOptionsListView.Items.Clear();

            for (int row = 0; row < optionsList.GetLength(0); row++)
            {
                if (optionsList[row, 3] != changedOptions[row, 3])
                {
                    ListViewItem newItem = ChangedOptionsListView.Items.Add(changedOptions[row, 1]);
                    newItem.SubItems.Add(changedOptions[row, 2]);
                    newItem.SubItems.Add(changedOptions[row, 3]);
                }
            }
        }

        // Export only the modified options as an array
        private string[,] ExportSavedOptionsAsArray()
        {
            var selectedIndicesList = new List<int>();

            for (int row = 0; row < optionsList.GetLength(0); row++)
            {
                if (optionsList[row, 3] != changedOptions[row, 3])
                {
                    selectedIndicesList.Add(row);
                }
            }

            int[] selectedIndices = selectedIndicesList.ToArray();

            string[,] changedOptionsNoDesc = RemoveDescriptions(changedOptions);
            return SelectRows(changedOptionsNoDesc, selectedIndices);
        }

        // Select specific rows from the array
        private string[,] SelectRows(string[,] originalArray, int[] selectedIndices)
        {
            int numSelectedRows = selectedIndices.Length;
            int numCols = originalArray.GetLength(1);

            // Create a new array with the selected rows
            string[,] newArray = new string[numSelectedRows, numCols];

            // Copy the selected rows from the original array
            for (int i = 0; i < numSelectedRows; i++)
            {
                int rowIndex = selectedIndices[i];
                for (int j = 0; j < numCols; j++)
                {
                    newArray[i, j] = originalArray[rowIndex, j];
                }
            }

            return newArray;
        }

        // Remove descriptions from the array
        private string[,] RemoveDescriptions(string[,] originalArray)
        {
            int numRows = originalArray.GetLength(0);
            int numColumns = Math.Min(originalArray.GetLength(1), 4);

            string[,] newArray = new string[numRows, numColumns];

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numColumns; j++)
                {
                    newArray[i, j] = originalArray[i, j];
                }
            }

            return newArray;
        }

        // Handle the Close button being clicked
        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Handles the Reset button being clicked, resets all options to RDP defaults (so they are not active)
        private void ResetButton_Click(object sender, EventArgs e)
        {
            CopyOptions();
            UpdateChangedOptions();
            LoadSelected();
        }

        // Handles the Defaults button being clicked, clears all options and adds all recommended default options
        private void DefaultsButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("=== 应用推荐默认配置 ===");
            System.Diagnostics.Debug.WriteLine($"推荐配置数量: {RecommendedDefaultOptions.GetLength(0)}");
            
            CopyOptions();
            LoadAdditionalOptions(RecommendedDefaultOptions);
            UpdateChangedOptions();
            LoadSelected();
            
            System.Diagnostics.Debug.WriteLine($"应用后的已修改选项数量: {ChangedOptionsListView.Items.Count}");
        }

        // Handles items in the Changed Options ListView being clicked/selected, scrolls to the selected option in the main Options ListBox
        private void ChangedOptionsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScrollToSelectedOption();
            ChangedOptionsListView.Focus();
        }

        // As above, scrolls to the selected option in the main Options ListBox
        private void ScrollToSelectedOption()
        {
            if (ChangedOptionsListView.SelectedItems.Count > 0)
            {
                string selectedOptionName = ChangedOptionsListView.SelectedItems[0].Text;
                OptionsListBox.SelectedItem = selectedOptionName;
            }
        }

        private void ResetValueButton_Click(object sender, EventArgs e)
        {
            if (ValueTextBox.Text != optionsList[selectedRow, 3])
            {
                changedOptions[selectedRow, 3] = optionsList[selectedRow, 3];
                LoadSelected();
                UpdateChangedOptions();
            }
        }

        /// <summary>
        /// 手动初始化ImageList，使用系统图标作为临时解决方案
        /// </summary>
        private void InitializeImageList()
        {
            try
            {
                // 检查SmallerIcons是否为空，只有为空时才添加系统图标
                if (this.SmallerIcons.Images.Count == 0)
                {
                    // 添加7个图标位置（索引0-6），使用系统图标作为占位符
                    // 0: save-as_16x16.png - 保存图标
                    this.SmallerIcons.Images.Add(SystemIcons.Application.ToBitmap());
                    // 1: msi small.ico - MSI图标
                    this.SmallerIcons.Images.Add(SystemIcons.WinLogo.ToBitmap());
                    // 2: doc_file_document_manager_paper_phone.ico - 文档图标
                    this.SmallerIcons.Images.Add(SystemIcons.Information.ToBitmap());
                    // 3: 16.ico - 信息图标
                    this.SmallerIcons.Images.Add(SystemIcons.Information.ToBitmap());
                    // 4: cross.ico - 取消图标
                    this.SmallerIcons.Images.Add(SystemIcons.Error.ToBitmap());
                    // 5: pictures (1).ico - 图片图标
                    this.SmallerIcons.Images.Add(SystemIcons.Question.ToBitmap());
                    // 6: Remote Desktop Connection.ico - 远程桌面图标
                    this.SmallerIcons.Images.Add(SystemIcons.Application.ToBitmap());
                }
                
                System.Diagnostics.Debug.WriteLine($"RDPOptionsWindow ImageList初始化完成，共{this.SmallerIcons.Images.Count}个图标");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"初始化ImageList失败: {ex.Message}");
                // 即使失败也不抛出异常，让窗口继续加载
            }
        }
    }
}