using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RAFContext
    {
        private string fileName;
        private int size;

        public RAFContext(string fileName, int size)
        {
            this.fileName = fileName;
            this.size = size;
        }

        public Stream HeaderStream
        {
            get => File.Open($"{fileName}.hd", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public Stream DataStream
        {
            get => File.Open($"{fileName}.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public void Create<T>(T t)
        {
            try
            {
                using (BinaryWriter bwHeader = new BinaryWriter(HeaderStream),
                                                  bwData = new BinaryWriter(DataStream))
                {
                    int n = 0, k = 0;
                    using (BinaryReader brHeader = new BinaryReader(bwHeader.BaseStream))
                    {
                        if (brHeader.BaseStream.Length > 0)
                        {
                            brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                            n = brHeader.ReadInt32();
                            k = brHeader.ReadInt32();
                        }

                        //calculamos la posicion en Data
                        long pos = k * size;
                        bwData.BaseStream.Seek(pos, SeekOrigin.Begin);

                        PropertyInfo[] info = t.GetType().GetProperties();
                        foreach (PropertyInfo pinfo in info)
                        {
                            Type type = pinfo.PropertyType;
                            object obj = pinfo.GetValue(t, null);

                            if (type.IsGenericType)
                            {
                                continue;
                            }

                            if (pinfo.Name.Equals("Id", StringComparison.CurrentCultureIgnoreCase))
                            {
                                bwData.Write(++k);
                                continue;
                            }

                            if (type == typeof(int))
                            {
                                bwData.Write((int)obj);
                            }
                            else if (type == typeof(long))
                            {
                                bwData.Write((long)obj);
                            }
                            else if (type == typeof(float))
                            {
                                bwData.Write((float)obj);
                            }
                            else if (type == typeof(double))
                            {
                                bwData.Write((double)obj);
                            }
                            else if (type == typeof(decimal))
                            {
                                bwData.Write((decimal)obj);
                            }
                            else if (type == typeof(char))
                            {
                                bwData.Write((char)obj);
                            }
                            else if (type == typeof(bool))
                            {
                                bwData.Write((bool)obj);
                            }
                            else if (type == typeof(string))
                            {
                                bwData.Write((string)obj);
                            }
                        }

                        long posh = 8 + n * 4;
                        bwHeader.BaseStream.Seek(posh, SeekOrigin.Begin);
                        bwHeader.Write(k);

                        bwHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                        bwHeader.Write(++n);
                        bwHeader.Write(k);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public T Get<T>(int id)
        {
            try
            {
                T newValue = (T)Activator.CreateInstance(typeof(T));
                int n = 0, k = 0;
                using (BinaryReader brHeader = new BinaryReader(HeaderStream),
                                    brData = new BinaryReader(DataStream))
                {
                    if(brHeader.BaseStream.Length > 0)
                    {
                        brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                        n = brHeader.ReadInt32();
                        k = brHeader.ReadInt32();
                    }
                    
                    if(n == 0)
                    {
                        return default(T);
                    }

                    if (id <= 0 || id > k)
                    {
                        return default(T);
                    }

                    PropertyInfo[] properties = newValue.GetType().GetProperties();
                    long posh = 8 + (id - 1) * 4;
                    //TODO Add Binary search to find the id
                    brHeader.BaseStream.Seek(posh, SeekOrigin.Begin);
                    int index = brHeader.ReadInt32();

                    if (index != id)
                    {
                        return default(T);
                    }

                    long posd = (index - 1) * size;
                    brData.BaseStream.Seek(posd, SeekOrigin.Begin);
                    foreach (PropertyInfo pinfo in properties)
                    {
                        Type type = pinfo.PropertyType;

                        if (type.IsGenericType)
                        {
                            continue;
                        }

                        if (type == typeof(int))
                        {
                            pinfo.SetValue(newValue, brData.GetValue<int>(TypeCode.Int32));
                        }
                        else if (type == typeof(long))
                        {
                            pinfo.SetValue(newValue, brData.GetValue<long>(TypeCode.Int64));
                        }
                        else if (type == typeof(float))
                        {
                            pinfo.SetValue(newValue, brData.GetValue<float>(TypeCode.Single));
                        }
                        else if (type == typeof(double))
                        {
                            pinfo.SetValue(newValue, brData.GetValue<double>(TypeCode.Double));
                        }
                        else if (type == typeof(decimal))
                        {
                            pinfo.SetValue(newValue, brData.GetValue<decimal>(TypeCode.Decimal));
                        }
                        else if (type == typeof(char))
                        {
                            pinfo.SetValue(newValue, brData.GetValue<char>(TypeCode.Char));
                        }
                        else if (type == typeof(bool))
                        {
                            pinfo.SetValue(newValue, brData.GetValue<bool>(TypeCode.Boolean));
                        }
                        else if (type == typeof(string))
                        {
                            pinfo.SetValue(newValue, brData.GetValue<string>(TypeCode.String));
                        }
                    }                    
                }
                return newValue;
            }
            catch (Exception)
            {
                throw;
            }
            

        }

        public List<T> GetAll<T>()
        {
            List<T> listT = new List<T>();
            int n = 0;
            try
            {
                using (BinaryReader brHeader = new BinaryReader(HeaderStream))
                {
                    if(brHeader.BaseStream.Length > 0)
                    {
                        brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                        n = brHeader.ReadInt32();                        
                    }                    
                }

                if(n == 0)
                {
                    return listT;
                }

                for (int i = 0; i < n; i++)
                {
                    int index;
                    using (BinaryReader brHeader = new BinaryReader(HeaderStream))
                    {
                        long posh = 8 + i * 4;
                        brHeader.BaseStream.Seek(posh, SeekOrigin.Begin);
                        index = brHeader.ReadInt32();
                        if (index == 0)
                        {
                            continue;
                        }
                    }

                    T t = Get<T>(index);
                    listT.Add(t);
                }

                return listT;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public List<T> Find<T>(Expression<Func<T, bool>> where)
        {
            List<T> listT = new List<T>();
            int n = 0, k = 0;
            Func<T, bool> comparator = where.Compile();
            try
            {
                using (BinaryReader brHeader = new BinaryReader(HeaderStream))
                {
                    if (brHeader.BaseStream.Length > 0)
                    {
                        brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                        n = brHeader.ReadInt32();
                        k = brHeader.ReadInt32();
                    }
                }

                if (n == 0)
                {
                    return listT;
                }

                for (int i = 0; i < n; i++)
                {
                    int index;
                    using (BinaryReader brHeader = new BinaryReader(HeaderStream))
                    {
                        long posh = 8 + i * 4;
                        brHeader.BaseStream.Seek(posh, SeekOrigin.Begin);
                        index = brHeader.ReadInt32();
                    }

                    T t = Get<T>(index);
                    if (comparator(t))
                    {
                        listT.Add(t);
                    }

                }
                return listT;
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public void Update<T>(T t)
        {
            int Id = int.Parse(t.GetType().GetProperty("Id").GetValue(t).ToString());

            using (BinaryReader brHeader = new BinaryReader(HeaderStream),
                                brData = new BinaryReader(DataStream))
            {
                int n, k;
                brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                if (brHeader.BaseStream.Length == 0)
                {
                    n = 0;
                    k = 0;
                    return;
                }
                n = brHeader.ReadInt32();
                k = brHeader.ReadInt32();

                long posh = 8 + (Id - 1) * 4;
                brHeader.BaseStream.Seek(posh, SeekOrigin.Begin);
                long index = brHeader.ReadInt32();
                long posd = (index - 1) * size;
                brData.Close();
                brHeader.Close();
                using (BinaryWriter binaryHeader = new BinaryWriter(HeaderStream),
                                   binaryData = new BinaryWriter(DataStream))
                {
                    PropertyInfo[] propertyInfo = t.GetType().GetProperties();



                    binaryData.BaseStream.Seek(posd, SeekOrigin.Begin);
                    foreach (PropertyInfo pinfo in propertyInfo)
                    {
                        Type type = pinfo.PropertyType;
                        object obj = pinfo.GetValue(t, null);

                        if (type.IsGenericType)
                        {
                            continue;
                        }
                        if (type == typeof(int))
                        {
                            binaryData.Write((int)obj);
                        }
                        else if (type == typeof(long))
                        {
                            binaryData.Write((long)obj);
                        }
                        else if (type == typeof(float))
                        {
                            binaryData.Write((float)obj);
                        }
                        else if (type == typeof(double))
                        {
                            binaryData.Write((double)obj);
                        }
                        else if (type == typeof(decimal))
                        {
                            binaryData.Write((decimal)obj);
                        }
                        else if (type == typeof(char))
                        {
                            binaryData.Write((char)obj);
                        }
                        else if (type == typeof(bool))
                        {
                            binaryData.Write((bool)obj);
                        }
                        else if (type == typeof(string))
                        {
                            binaryData.Write((string)obj);
                        }
                    }
                }
            }
        }

        public void Delete(int id)
        {
            long pos = GetPosition(id);
            using (BinaryWriter bwHeader = new BinaryWriter(HeaderStream))
            {

                bwHeader.BaseStream.Seek(pos, SeekOrigin.Begin);
                bwHeader.Write(0);

            }
        }
        public int GetPosition(int id)
        {

            int index = 0;
            int n = 0;

            using (BinaryReader brHeader = new BinaryReader(HeaderStream))
            {
                if (brHeader.BaseStream.Length > 0)
                {
                    brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                    n = brHeader.ReadInt32();
                }
            }

            for (int i = 0; i < n; i++)
            {

                using (BinaryReader brHeader = new BinaryReader(HeaderStream))
                {
                    long posh = 8 + i * 4;
                    brHeader.BaseStream.Seek(posh, SeekOrigin.Begin);
                    if (id == brHeader.ReadInt32())
                    {
                        return index = (int)posh;

                    }

                }


            }
            return index;
        }
    }
}
