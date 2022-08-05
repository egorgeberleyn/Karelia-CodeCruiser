:: This file contains settings for remote deploy logic.
:: You can create multi configuration adding postfix to variable name. For example, "SET DeployFTPProtocol_production".
:: With multi configuration you can use any configuration with deploy cmd files. For example, "Deploy.Full.cmd _production".
:: Ftp protocol options: Sftp = 0, Scp = 1, Ftp = 2, Webdav = 3

:: DEFAULT CONFIGURATION
:: FTP Settings
SET ServerHostName=
SET ServerPortNumber=
SET ServerProtocol=2
SET ServerUserName=
SET ServerPassword=
SET ServerRemoteFolder=
SET ClientHostName=
SET ClientPortNumber=
SET ClientProtocol=2
SET ClientUserName=
SET ClientPassword=
SET ClientRemoteFolder=
:: Database
SET DBServer=
SET DBName=Karelia
SET DBUserName=sa
SET DBPassword=

:: SECOND CONFIGURATION EXAMPLE (_production)
:: FTP Settings
:: SET ServerHostName_production=
:: SET ServerPortNumber_production=
:: SET ServerProtocol_production=2
:: SET ServerUserName_production=
:: SET ServerPassword_production=
:: SET ServerRemoteFolder_production=
:: SET ClientHostName_production=
:: SET ClientPortNumber_production=
:: SET ClientProtocol_production=2
:: SET ClientUserName_production=
:: SET ClientPassword_production=
:: SET ClientRemoteFolder_production=
:: Database
:: SET DBServer_production=
:: SET DBName_production=Karelia
:: SET DBUserName_production=sa
:: SET DBPassword_production=
