﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2017/09/06 1:54:40
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Data;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;

namespace EasyTodoCoreASP
{
    public partial class TodoDetailData {

        public TodoDetailData()
        {
            OnCreated();
        }

        public virtual int UserId
        {
            get;
            set;
        }

        public virtual int DataId
        {
            get;
            set;
        }

        public virtual string Title
        {
            get;
            set;
        }

        public virtual string Detail
        {
            get;
            set;
        }

        public virtual System.Nullable<System.DateTime> StartDate
        {
            get;
            set;
        }

        public virtual System.Nullable<System.DateTime> EndDate
        {
            get;
            set;
        }

        public virtual System.Nullable<int> State
        {
            get;
            set;
        }

        public virtual System.Nullable<int> ColorId
        {
            get;
            set;
        }
    
        #region Extensibility Method Definitions

        partial void OnCreated();

        public override bool Equals(object obj)
        {
          TodoDetailData toCompare = obj as TodoDetailData;
          if (toCompare == null)
          {
            return false;
          }

          if (!Object.Equals(this.UserId, toCompare.UserId))
            return false;
          if (!Object.Equals(this.DataId, toCompare.DataId))
            return false;
          
          return true;
        }

        public override int GetHashCode()
        {
          int hashCode = 13;
          hashCode = (hashCode * 7) + UserId.GetHashCode();
          hashCode = (hashCode * 7) + DataId.GetHashCode();
          return hashCode;
        }
        
        #endregion
    }

}
