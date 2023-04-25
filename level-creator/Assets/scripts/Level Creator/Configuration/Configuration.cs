using UnityEngine;

using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using Newtonsoft.Json;

public class Configuration<T>
{
    private string defaultFolder = Application.persistentDataPath;
    private string filePath;

    private SaveType saveType;

    private BinaryFormatter binaryFormatter;
    private XmlSerializer xmlSerializer;

    public Configuration(string file, string folder = "", SaveType saveType = SaveType.JSON)
    {
        // Make sure a file name is provided, folder is optional
        if (string.IsNullOrEmpty(file)) return;

        // No folder is provided
        if (string.IsNullOrEmpty(folder))
        {
            filePath = Path.Combine(defaultFolder, file);
        }
        else
        {
            // Folder is provided
            filePath = Path.Combine(defaultFolder + Path.DirectorySeparatorChar + folder, file);
        }

        // Set save type
        this.saveType = saveType;

        // Instaniate new binary formatter
        binaryFormatter = new BinaryFormatter();

        // Instaniate new xml serializer
        xmlSerializer = new XmlSerializer(typeof(T));
    }

    public T Load()
    {
        // Make sure file exists before loading it
        if (!File.Exists(filePath))
            throw new FileNotFoundException("Failed to load data, no file found at location: " + filePath);

        using (StreamReader reader = new StreamReader(filePath))
        {
            switch (saveType)
            {
                case SaveType.BINARY:
                    try
                    {
                        // Deserialize data from binary and return it
                        return (T)binaryFormatter.Deserialize(reader.BaseStream);
                    }
                    catch (SerializationException e)
                    {
                        // Log error if deserialization fails
                        Debug.LogError("Failed to deserialize from binary: " + e.Message);
                    }
                    break;
                case SaveType.JSON:
                    try
                    {
                        // Deserialize data from JSON and return it
                        return JsonConvert.DeserializeObject<T>(reader.ReadToEnd());

                    }
                    catch (JsonSerializationException e)
                    {
                        Debug.LogError("Failed to deserialize from JSON: " + e.Message);
                    }
                    break;
                case SaveType.XML:
                    try
                    {
                        // Deserialize data from XML and return it
                        return (T)xmlSerializer.Deserialize(reader.BaseStream);
                    }
                    catch (SerializationException e)
                    {
                        // Log error if deserialization fails
                        Debug.LogError("Failed to deserialize from binary: " + e.Message);
                    }
                    break;
                default:
                    break;
            }
        }
        return default(T);
    }

    public void Save(T data)
    {
        // Create directory if it doesn't exist
        if (!Directory.Exists(Path.GetDirectoryName(filePath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        }

        // Save data to file
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            switch (saveType)
            {
                case SaveType.BINARY:
                    try
                    {
                        // Serialize data to binary
                        binaryFormatter.Serialize(writer.BaseStream, data);
                    }
                    catch (SerializationException e)
                    {
                        // Log error if serialization fails
                        Debug.LogError("Failed to serialize to binary: " + e.Message);
                    }
                    break;

                case SaveType.JSON:
                    try
                    {
                        // Serialize data to JSON
                        writer.Write(JsonConvert.SerializeObject(data, Formatting.Indented));
                    }
                    catch (JsonSerializationException e)
                    {
                        // Log error if serialization fails
                        Debug.LogError("Failed to serialize to JSON: " + e.Message);
                    }
                    break;
                case SaveType.XML:
                    try
                    {
                        // Serialize data to XML
                        xmlSerializer.Serialize(writer.BaseStream, data);
                    }
                    catch (SerializationException e)
                    {
                        // Log error if serialization fails
                        Debug.LogError("Failed to serialize to XML: " + e.Message);
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public string GetFolderPath()
    {
        return Path.GetDirectoryName(filePath);
    }

    public string GetFilePath()
    {
        return filePath;
    }

    public SaveType GetSaveType()
    {
        return saveType;
    }
}
