using System;
using CarStorageLibrary.StorageImpl;

namespace CarStorageLibrary
{
    class StorageFactory
    {
        public static IStorage CreateMemoryStorage()
        {
            return InMemoryStorage.Instance;
        }

        public static IStorage CreateBinarryStorage(string path)
        {
            return new BinarryStorage(path);
        }

        public static IStorage CreateCsvStorage(string path)
        {
            return new CsvStorage(path);
        }
    }
}
