%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe /name="Macaque Base Service" "%~dp0Macaque.Base.Service.exe"
Net Start ServiceTest
sc config ServiceTest start= auto
@pause