using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Chainblock.Contracts;

namespace Chainblock.Models
{
    public class Chainblock : IChainblock
    {
        private Dictionary<int, ITransaction> items;

        public Chainblock()
        {
            this.items = new Dictionary<int, ITransaction>();
        }

        public int Count => this.items.Count;

        public void Add(ITransaction tx)
        {
            if (!this.items.ContainsKey(tx.Id))
            {
                this.items[tx.Id] = tx;
            }
            else
            {
                throw new ArgumentException("This transaction already exists.");
            }
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (this.items.ContainsKey(id))
            {
                this.items[id].Status = newStatus;
            }
            else
            {
                throw new ArgumentException("There is no such transaction");
            }
        }

        public bool Contains(ITransaction tx)
        {
            return this.items.ContainsKey(tx.Id);
        }

        public bool Contains(int id)
        {
            return this.items.ContainsKey(id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            return this.items.Values.Where(t => t.Amount >= lo && t.Amount <= hi);
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.items.Values.OrderByDescending(t => t.Amount).ThenBy(t => t.Id);
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            var toReturn = this.items.Where(t => t.Value.Status == status).OrderBy(t => t.Value.Amount).Select(t => t.Value.To);

            if (toReturn.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return toReturn;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            var toReturn = this.items.Where(t => t.Value.Status == status).OrderBy(t => t.Value.Amount).Select(t => t.Value.From);

            if (toReturn.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return toReturn;
        }

        public ITransaction GetById(int id)
        {
            if (!this.items.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            return this.items[id];
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            var toReturn = this.items.Values.Where(t => t.To == receiver && t.Amount >= lo && t.Amount < hi).OrderByDescending(t => t.Amount).ThenBy(t => t.Id);

            this.EnsureCollectionIsNotEmpty(toReturn);

            return toReturn;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            var toReturn = this.items.Values.Where(t => t.From == receiver).OrderByDescending(t => t.Amount).ThenBy(t => t.Id);

            this.EnsureCollectionIsNotEmpty(toReturn);

            return toReturn;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            var toReturn = this.items.Values.Where(t => t.From == sender && t.Amount > amount).OrderByDescending(t => t.Amount);

            this.EnsureCollectionIsNotEmpty(toReturn);

            return toReturn;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            var toReturn = this.items.Values.Where(t => t.From == sender).OrderByDescending(t => t.Amount);

            this.EnsureCollectionIsNotEmpty(toReturn);

            return toReturn;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            IEnumerable<ITransaction> toReturn = this.items.Where(t => t.Value.Status == status).OrderByDescending(t => t.Value.Amount).Select(t => t.Value);

            this.EnsureCollectionIsNotEmpty(toReturn);

            return toReturn;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            return this.items.Values.Where(t => t.Status == status && t.Amount <= amount).OrderByDescending(t => t.Amount);
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            if (!this.items.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            this.items.Remove(id);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        private void EnsureCollectionIsNotEmpty(IEnumerable<ITransaction> collection)
        {
            if (collection.Count() == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
