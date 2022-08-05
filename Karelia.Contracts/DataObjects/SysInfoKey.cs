using System;
using System.ComponentModel;
using BusinessFramework.Contracts;
using BusinessFramework.Contracts.Utils;


namespace Karelia.Contracts.DataObjects
{
    [Serializable]
    [TypeConverter(typeof (JsonUriConverter<SysInfoKey, SysInfoKeyData>))]
    public struct SysInfoKey : IEquatable<SysInfoKey>, IJsonUri
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        public SysInfoKey(string systemVersion, string domainVersion, DateTimeOffset lastInitialization)
            : this()
        {
            this.SystemVersion = systemVersion;        
            this.DomainVersion = domainVersion;        
            this.LastInitialization = lastInitialization;        
        }

        public string SystemVersion { get; private set; }
        public string DomainVersion { get; private set; }
        public DateTimeOffset LastInitialization { get; private set; }

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        ///     true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(SysInfoKey other)
        {
            return Equals(SystemVersion, other.SystemVersion) && Equals(DomainVersion, other.DomainVersion) && Equals(LastInitialization, other.LastInitialization);
        }
        /// <summary>
        ///     Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="obj" /> and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        /// <param name="obj">Another object to compare to. </param>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            return obj is SysInfoKey && Equals((SysInfoKey) obj);
        }
        /// <summary>
        ///     Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 0;
                hashCode = (hashCode*397) ^ SystemVersion.GetHashCode();
                hashCode = (hashCode*397) ^ DomainVersion.GetHashCode();
                hashCode = (hashCode*397) ^ LastInitialization.GetHashCode();
                return hashCode;
            }
        }

		public static bool operator ==(SysInfoKey left, SysInfoKey right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(SysInfoKey left, SysInfoKey right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        ///     Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:System.String" /> containing a fully qualified type name.
        /// </returns>
        public override string ToString()
        {
		    return string.Format("SystemVersion:{0}, DomainVersion:{0}, LastInitialization:{0}", SystemVersion, DomainVersion, LastInitialization);
        }

        /// <summary>
        ///     Serialization data
        /// </summary>
        object IJsonUri.Data
        {
            get { return new SysInfoKeyData(SystemVersion, DomainVersion, LastInitialization); }
        }
    }

    [Serializable]
    public struct SysInfoKeyData : IConvertable<SysInfoKey>
    {
        public SysInfoKeyData(string systemVersion, string domainVersion, DateTimeOffset lastInitialization)
            : this()
        {
            SystemVersion = systemVersion;        
            DomainVersion = domainVersion;        
            LastInitialization = lastInitialization;        
        }

        public string SystemVersion { get; private set; }
        public string DomainVersion { get; private set; }
        public DateTimeOffset LastInitialization { get; private set; }

        public SysInfoKey Convert()
        {
            return new SysInfoKey(SystemVersion, DomainVersion, LastInitialization);
        }
    }
}