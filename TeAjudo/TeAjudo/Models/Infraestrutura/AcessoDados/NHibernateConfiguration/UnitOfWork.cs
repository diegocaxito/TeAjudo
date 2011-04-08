using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace TeAjudo.Models.Infraestrutura.AcessoDados.NHibernateConfiguration
{
    public interface IUnitOfWork : IDisposable
    {
        void Begin();
        void Commit();
        void RollBack();
        ISession CurrentSession { get; }
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISessionBuilder sessionBuilder;
        private ITransaction transaction;
        private bool begun;
        private bool disposed;
        private bool rolledBack;

        public UnitOfWork(ISessionBuilder sessionSource)
        {
            sessionBuilder = sessionSource;
        }

        public void Begin()
        {
            CheckIsDisposed();
            CurrentSession = sessionBuilder.CreateSession();

            BeginNewTransaction();
            begun = true;
        }

        public void Commit()
        {
            CheckIsDisposed();
            CheckHasBegun();

            if (transaction.IsActive && !rolledBack)
            {
                transaction.Commit();
            }
            BeginNewTransaction();
        }

        public void RollBack()
        {
            CheckIsDisposed();
            CheckHasBegun();
            if (transaction.IsActive)
            {
                transaction.Rollback();
                rolledBack = true;
            }
            BeginNewTransaction();
        }

        public ISession CurrentSession { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void BeginNewTransaction()
        {
            if(transaction!=null)
                transaction.Dispose();
            transaction = CurrentSession.BeginTransaction();
        }

        private void Dispose(bool disposing)
        {
            if(!begun || disposed)
                return;
            if(disposing)
            {
                transaction.Dispose();
                CurrentSession.Dispose();
            }
            disposed = true;
        }

        private void CheckHasBegun()
        {
            if(!begun)
                throw new InvalidOperationException("Must call Begin() on the unit of work before committing.");
        }

        private void CheckIsDisposed()
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
        }
    }
}