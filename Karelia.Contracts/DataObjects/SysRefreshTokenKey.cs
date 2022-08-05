using System;
using System.ComponentModel;
using BusinessFramework.Contracts;
using BusinessFramework.Contracts.Utils;


namespace Karelia.Contracts.DataObjects
{
    [Serializable]
    [TypeConverter(typeof (JsonUriConverter<SysRefreshTokenKey, SysRefreshTokenKeyData>))]
    public struct SysRefreshTokenKey : IEquatable<SysRefreshTokenKey>, IJsonUri
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        public SysRefreshTokenKey(int userId, string clientId)
            : this()
        {
            this.UserId = userId;        
            this.ClientId = clientId;        
        }

        public int UserId { get; private set; }
        public string ClientId { get; private set; }

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        ///     true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(SysRefreshTokenKey other)
        {
            return Equals(UserId, other.UserId) && Equals(ClientId, other.ClientId);
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
            return obj is SysRefreshTokenKey && Equals((SysRefreshTokenKey) obj);
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
                hashCode = (hashCode*397) ^ UserId.GetHashCode();
                hashCode = (hashCode*397) ^ ClientId.GetHashCode();
                return hashCode;
            }
        }

		public static bool operator ==(SysRefreshTokenKey left, SysRefreshTokenKey right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(SysRefreshTokenKey left, SysRefreshTokenKey right)
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
		    return string.Format("UserId:{0}, ClientId:{0}", UserId, ClientId);
        }

        /// <summary>
        ///     Serialization data
        /// </summary>
        object IJsonUri.Data
        {
            get { return new SysRefreshTokenKeyData(UserId, ClientId); }
        }
    }

    [Serializable]
    public struct SysRefreshTokenKeyData : IConvertable<SysRefreshTokenKey>
    {
        public SysRefreshTokenKeyData(int userId, string clientId)
            : this()
        {
            UserId = userId;        
            ClientId = clientId;        
        }

        public int UserId { get; private set; }
        public string ClientId { get; private set; }

        public SysRefreshTokenKey Convert()
        {
            return new SysRefreshTokenKey(UserId, ClientId);
        }
    }
}