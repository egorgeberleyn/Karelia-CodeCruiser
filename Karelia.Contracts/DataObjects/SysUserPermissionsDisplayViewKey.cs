using System;
using System.ComponentModel;
using BusinessFramework.Contracts;
using BusinessFramework.Contracts.Utils;


namespace Karelia.Contracts.DataObjects
{
    [Serializable]
    [TypeConverter(typeof (JsonUriConverter<SysUserPermissionsDisplayViewKey, SysUserPermissionsDisplayViewKeyData>))]
    public struct SysUserPermissionsDisplayViewKey : IEquatable<SysUserPermissionsDisplayViewKey>, IJsonUri
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        public SysUserPermissionsDisplayViewKey(int userId, int permissionId)
            : this()
        {
            this.UserId = userId;        
            this.PermissionId = permissionId;        
        }

        public int UserId { get; private set; }
        public int PermissionId { get; private set; }

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        ///     true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(SysUserPermissionsDisplayViewKey other)
        {
            return Equals(UserId, other.UserId) && Equals(PermissionId, other.PermissionId);
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
            return obj is SysUserPermissionsDisplayViewKey && Equals((SysUserPermissionsDisplayViewKey) obj);
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
                hashCode = (hashCode*397) ^ PermissionId.GetHashCode();
                return hashCode;
            }
        }

		public static bool operator ==(SysUserPermissionsDisplayViewKey left, SysUserPermissionsDisplayViewKey right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(SysUserPermissionsDisplayViewKey left, SysUserPermissionsDisplayViewKey right)
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
		    return string.Format("UserId:{0}, PermissionId:{0}", UserId, PermissionId);
        }

        /// <summary>
        ///     Serialization data
        /// </summary>
        object IJsonUri.Data
        {
            get { return new SysUserPermissionsDisplayViewKeyData(UserId, PermissionId); }
        }
    }

    [Serializable]
    public struct SysUserPermissionsDisplayViewKeyData : IConvertable<SysUserPermissionsDisplayViewKey>
    {
        public SysUserPermissionsDisplayViewKeyData(int userId, int permissionId)
            : this()
        {
            UserId = userId;        
            PermissionId = permissionId;        
        }

        public int UserId { get; private set; }
        public int PermissionId { get; private set; }

        public SysUserPermissionsDisplayViewKey Convert()
        {
            return new SysUserPermissionsDisplayViewKey(UserId, PermissionId);
        }
    }
}