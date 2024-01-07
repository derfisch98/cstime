using De.HsFlensburg.cstime079.Business.Model.BusinessObjects;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace De.HsFlensburg.cstime079.Services.SerializationService
{
    public class ModelFileHandler
    {
        public TimerGroup ReadModelFromFile(string path)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream streamLoad = new FileStream(
                path,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read);
            TimerGroup loadedGroup =
                (TimerGroup)formatter.Deserialize(streamLoad);
            streamLoad.Close();

            return loadedGroup;
        }

        public void WriteModelToFile(string path, TimerGroup model)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(
                path,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None);
            formatter.Serialize(stream, model);
            stream.Close();
        }
    }
}
