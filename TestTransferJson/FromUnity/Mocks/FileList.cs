using ConsoleForUnity;
using MessageObjects;

namespace TestTransferJson.FromUnity.Mocks;

public class FileList
{
    public void BuildView(FileSystem myDeserializedClass)
    {
       ConsoleInTextView.ShowMessage("BuildView выполнился, вывел:");
       ConsoleInTextView.ShowSend(myDeserializedClass.ToString());
       ConsoleInTextView.ShowMessage("BuildView конец вывода");
    }
}
