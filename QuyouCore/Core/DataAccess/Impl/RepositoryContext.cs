using System.Data;
using System.Data.Linq;

namespace QuyouCore.Core.DataAccess.Impl
{
    public class RepositoryContext : DataContext, IRepositoryContext
    {
        public RepositoryContext()
            : base(new Connection().GetCurrentConnectionString())
        {


        }

        #region Constructors

        public RepositoryContext(IDbConnection connection)
            : this(connection, true)
        {
        }

        public RepositoryContext(IDbConnection connection, bool isReadOnly)
            : base(connection)
        {
            ResetContext(isReadOnly);
        }

        public RepositoryContext(string fileOrServerOrConnection)
            : this(fileOrServerOrConnection, true)
        {
        }

        public RepositoryContext(string fileOrServerOrConnection, bool isReadOnly)
            : base(fileOrServerOrConnection)
        {
            ResetContext(isReadOnly);
        }

        #endregion

        #region IRepositoryContext Members

        private bool _isReadOnly = true;

        public bool IsReadOnly
        {
            get
            {
                return _isReadOnly;
            }
        }

        #endregion

        #region Internal methods

        internal void ResetContext(bool isReadOnly)
        {
            _isReadOnly = isReadOnly;
            this.ObjectTrackingEnabled = !_isReadOnly;
            if (!isReadOnly)
                this.DeferredLoadingEnabled = !isReadOnly;
        }

        #endregion
    }
}
