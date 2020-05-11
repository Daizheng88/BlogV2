using Blog.Contract.Injections;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Blog.Application.Bus.Notify
{
    [Scope]
    public class Notifier : INotifier
    {
        public Notifier()
        {
            this.Contanier = new Dictionary<string, List<string>>();
        }

        public Dictionary<string, List<string>> Contanier { get; set; }

        public void Notice<T>(string content)
        {
            this.Notice(typeof(T).Name, content);
        }

        public void Notice(string title, string content)
        {
            if (!this.Contanier.ContainsKey(title))
            {
                this.Contanier[title] = new List<string>();
            }

            this.Contanier[title].Add(content);
        }

        public void NoticeError(string content)
        {
            if (!this.Contanier.ContainsKey("Error"))
            {
                this.Contanier["Error"] = new List<string>();
            }

            this.Contanier["Error"].Add(content);
        }

        public void NoticeErrors(ValidationResult result)
        {
            if (result == null || result.Errors.Count == 0)
            {
                return;
            }

            for (int i = 0; i < result.Errors.Count; i++)
            {
                this.NoticeError(result.Errors[i].ErrorMessage);
            }
        }
    }
}
