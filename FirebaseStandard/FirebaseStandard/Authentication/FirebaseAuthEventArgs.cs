﻿namespace FirebaseStandard.Authentication
{
    using System;

    public class FirebaseAuthEventArgs : EventArgs
    {
        public readonly FirebaseAuth FirebaseAuth;

        public FirebaseAuthEventArgs(FirebaseAuth auth)
        {
            this.FirebaseAuth = auth;
        }
    }
}
