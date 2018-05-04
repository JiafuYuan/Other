using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Model;

namespace Common.Interface
{
    public interface ICommand
    {
         void DoWork(CommandObjectModel cmdModel);
    }
}
