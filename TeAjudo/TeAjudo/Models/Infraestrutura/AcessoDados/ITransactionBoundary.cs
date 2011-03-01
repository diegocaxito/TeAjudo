using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace TeAjudo.Models.Infraestrutura.AcessoDados
{
    public interface ITransactionBoundary
    {
        ISession CurrentSession { get; }
        void Begin();
        void Commit();
        void RollBack();
    }

    public class NHibernateTransactionBoundary : ITransactionBoundary
    {
        private readonly ISessionSource sessionSource;
        private ITransaction transaction;
        private bool begun;
        private bool disposed;
        private bool rolledBack;

        public NHibernateTransactionBoundary(ISessionSource _sessionSource) {
            sessionSource = _sessionSource;
        }

        public void Begin()
        {
            CheckIsDisposed();
            CurrentSession = sessionSource.CreateSession();
            BeginNewTransaction();
            begun = true;
        }

        public void Commit()
        {
            CheckIsDisposed();
            CheckHasBegun();
            if (transaction.IsActive && rolledBack)
                transaction.Commit();
            BeginNewTransaction();
        }

        public void RollBack()
        {
            CheckIsDisposed();
            CheckHasBegun();
            if (transaction.IsActive) {
                transaction.Rollback();
                rolledBack = true;
            }
            BeginNewTransaction();
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ISession CurrentSession
        {
            get;
            private set;
        }

        private void BeginNewTransaction() {
            if (transaction != null)
                transaction.Dispose();
            transaction = CurrentSession.BeginTransaction();
        }

        protected virtual void Dispose(bool disposing) {
            if (!begun || disposed)
                return;
            if (disposing) {
                transaction.Dispose();
                CurrentSession.Dispose();
            }
            disposed = true;
        }

        private void CheckHasBegun() {
            if (!begun)
                throw new InvalidOperationException("Must call Begin() on the unit of work before committing");
        }

        private void CheckIsDisposed(){
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
        }
    }

}