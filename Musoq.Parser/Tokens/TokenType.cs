﻿namespace Musoq.Parser.Tokens
{
    public enum TokenType : short
    {
        Word,
        Decimal,
        LeftParenthesis,
        RightParenthesis,
        None,
        EndOfFile,
        Diff,
        And,
        Or,
        Not,
        Where,
        Plus,
        Star,
        FSlash,
        Hyphen,
        Mod,
        Comma,
        WhiteSpace,
        Equality,
        Column,
        NumericColumn,
        Function,
        Property,
        VarArg,
        Greater,
        GreaterEqual,
        Less,
        LessEqual,
        Select,
        From,
        Like,
        NotLike,
        As,
        Union,
        UnionAll,
        Except,
        Intersect,
        Dot,
        GroupBy,
        Having,
        Integer,
        KeyAccess,
        NumericAccess,
        AllColumns
    }
}