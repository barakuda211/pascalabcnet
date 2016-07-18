﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using PascalABCCompiler;
using PascalABCCompiler.SyntaxTree;

namespace SyntaxVisitors
{
    public class LocalVariablesTypeDetectorHelperVisior : BaseChangeVisitor
    {
        public List<var_def_statement> LocalDeletedDefs = new List<var_def_statement>(); // variable_definitions - описания до начала блока

        public List<var_def_statement> LocalDeletedVS = new List<var_def_statement>(); // var_statement's - внутриблочные описания

        public LocalVariablesTypeDetectorHelperVisior()
        {
        }

        public override void visit(yield_variable_definitions_with_unknown_type yvds)
        {
            // Empty
        }

        public override void visit(var_statement vs) // локальные описания внутри процедуры
        {

            LocalDeletedVS.Insert(0, vs.var_def);

            //ReplaceStatement(vs, new yield_var_def_statement_with_unknown_type(vs.var_def));
        }

        public override void visit(variable_definitions vd)
        {
            foreach (var v in vd.list)
            {
                LocalDeletedDefs.Insert(0, v); 
            }

            //Replace(vd, new yield_variable_definitions_with_unknown_type(vd));

            // еще - не заходить в лямбды
        }
    }
}
