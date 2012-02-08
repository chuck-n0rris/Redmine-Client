namespace Redmine.Client.Logic
{
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// Serializes and Deserializes the Redmine entities.
    /// </summary>
    public class Serializer
    {
        /// <summary>
        /// Serializes the specified entity.
        /// </summary>
        /// <typeparam name="T">Entity type.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// Xml in string.
        /// </returns>
        public static string Serialize<T>(T entity)
        {
            using (var memoryStream = new MemoryStream())
            using (var reader = new StreamReader(memoryStream))
            {
                var serializer = new XmlSerializer(typeof(T));

                serializer.Serialize(memoryStream, entity);

                memoryStream.Position = 0;
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Deserializes the specified XML.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="xml">The XML.</param>
        /// <returns>Deserialised entity.</returns>
        public static T Deserialize<T>(string xml)
        {
            using (Stream stream = new MemoryStream())
            {
                var data = System.Text.Encoding.UTF8.GetBytes(xml);

                stream.Write(data, 0, data.Length);
                stream.Position = 0;

                var serializer = new XmlSerializer(typeof(T));
                var entity = (T)serializer.Deserialize(stream);

                return entity;
            }
        }
    }
}