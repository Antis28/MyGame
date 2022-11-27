using System;

namespace TestTransferJson.FromUnity.Mocks;



/// <summary>
/// Mock НЕ ПЕРЕНОСИТЬ В UNITY
/// </summary>
public class Client 
{
    private static MobileClient _mobileClient;
    private static readonly string _ipAddressForServer = "192.168.0.101";
    private static  FileList uiFileList; // для вывода информации JSON файла структуры файловой системы компьютера

   
    public void StartClientAndServer()
    {
        _mobileClient = new MobileClient(_ipAddressForServer);
        MobileServer.Start(new FileList(), SendGetFileSystem);
    }
    
    public void SendGetFileSystem()
    {
        _mobileClient.StartMessages("GetFileSystem");
    }
    
    public void SendRight10()
    {
        _mobileClient.StartMessages("Right x 10");
    }

    public void SendRight()
    {
        _mobileClient.StartMessages("Right");
    }

    public void SendLeft10()
    {
        _mobileClient.StartMessages("Left x 10");
    }

    public void SendLeft()
    {
        _mobileClient.StartMessages("Left");
    }

    public void SendVolumeH()
    {
        _mobileClient.StartMessages("Volume +");
    }

    public void SendVolumeL()
    {
        _mobileClient.StartMessages("Volume -");
    }

    public void SendVolumeMute()
    {
        _mobileClient.StartMessages("Mute");
    }

    public void SendPageDown()
    {
        _mobileClient.StartMessages("PageDown");
    }

    public void SendPageUp()
    {
        _mobileClient.StartMessages("PageUp");
    }

    public void SendHibernate()
    {
        _mobileClient.StartMessages("Hibernate");
    }

    public void SendStandBy()
    {
        _mobileClient.StartMessages("StandBy");
    }

    /// <summary>
    /// Space используется по умолчанию на сервере
    /// </summary>
    public void SendSpace()
    {
        _mobileClient.StartMessages("Space");
    }

    public void SendWol()
    {
        throw new NotImplementedException();
    }

    public void SendSaveName()
    {
        _mobileClient.StartMessages("SaveName");
    }
}
