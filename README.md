# Security

Various useful security classes.

## Security.Secrets.ShamirSecretShare

Split a secret piece of information into x parts, requiring y pieces to obtain the original message. 
For example, you may have a password for an operation but require *any* 3 of 5 particular members of staff to ok it.

## Security.Secrets.Crypto.SymmetricCipher

Convenience wrapper to use BouncyCastle GCM block cipher.