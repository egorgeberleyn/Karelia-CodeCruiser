using System;
using System.ComponentModel;
using BusinessFramework.Contracts;
using BusinessFramework.Contracts.Utils;


namespace Karelia.Contracts.DataObjects
{
    [Serializable]
    [TypeConverter(typeof (JsonUriConverter<SysOperationLockKey, SysOperationLockKeyData>))]
    public struct SysOperationLockKey : IEquatable<SysOperationLockKey>, IJsonUri
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        public SysOperationLockKey(string operationName, string operationContext)
            : this()
        {
            this.OperationName = operationName;        
            this.OperationContext = operationContext;        
        }

        public string OperationName { get; private set; }
        public string OperationContext { get; private set; }

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        ///     true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(SysOperationLockKey other)
        {
            return Equals(OperationName, other.OperationName) && Equals(OperationContext, other.OperationContext);
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
            return obj is SysOperationLockKey && Equals((SysOperationLockKey) obj);
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
                hashCode = (hashCode*397) ^ OperationName.GetHashCode();
                hashCode = (hashCode*397) ^ OperationContext.GetHashCode();
                return hashCode;
            }
        }

		public static bool operator ==(SysOperationLockKey left, SysOperationLockKey right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(SysOperationLockKey left, SysOperationLockKey right)
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
		    return string.Format("OperationName:{0}, OperationContext:{0}", OperationName, OperationContext);
        }

        /// <summary>
        ///     Serialization data
        /// </summary>
        object IJsonUri.Data
        {
            get { return new SysOperationLockKeyData(OperationName, OperationContext); }
        }
    }

    [Serializable]
    public struct SysOperationLockKeyData : IConvertable<SysOperationLockKey>
    {
        public SysOperationLockKeyData(string operationName, string operationContext)
            : this()
        {
            OperationName = operationName;        
            OperationContext = operationContext;        
        }

        public string OperationName { get; private set; }
        public string OperationContext { get; private set; }

        public SysOperationLockKey Convert()
        {
            return new SysOperationLockKey(OperationName, OperationContext);
        }
    }
}