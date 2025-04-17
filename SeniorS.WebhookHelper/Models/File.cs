namespace SeniorS.WebhookHelper.Models;

public class File
{
    public byte[] Content { get; set; }
    
    public string Name { get; set; }
    
    public File(byte[] content, string name = "audio.wav")
    {
        Content = content;
        Name = name;
    }
}