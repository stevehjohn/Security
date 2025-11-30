# Security

Various useful security classes.

## Security.Console

Wrapper to execute the various functions.

### Splitting a secret

Change directory to `src/Security.Console`, then:

```
> dotnet run ToBase64 -t "This is a secret"

Original text: This is a secret

Base 64: VABoAGkAcwAgAGkAcwAgAGEAIABzAGUAYwByAGUAdAA=

> dotnet run SplitSecret -s VABoAGkAcwAgAGkAcwAgAGEAIABzAGUAYwByAGUAdAA= --Parts 6 -m 3

 1: wbHdhyMsmB0tFR0TN/ekJ/mL9v4nerTU9iIRDSsV70tX
 2: Ys5m0fnyge8q+ovn3F/O0OY7L4LgsJ50iMEy5RIwAqGt
 3: 8yu7Ptq3GYEHz5ad69tq1x/R2VzHuSrFfoAjmjlA7Z76
 4: FEz96iMAh0uPef+dXdfFDuu3E2tVh7787Lwk+C8tNV9N
 5: FakgBQBFHyWiTOLnalNhCRJd5bVyjgpNGv01hwRd2mAa
 6: ttabU9qbBtelo3QTgfsL/g3tPMm1RCDtZB4Wbz14N4rg

Any 3 of these can be combined to obtain the original secret.

> dotnet run Combine --Parts 3

  Please enter part 1
  > wbHdhyMsmB0tFR0TN/ekJ/mL9v4nerTU9iIRDSsV70tX
  > ********************************************
  Please enter part 2
  > 8yu7Ptq3GYEHz5ad69tq1x/R2VzHuSrFfoAjmjlA7Z76
  > ********************************************
  Please enter part 3
  > FakgBQBFHyWiTOLnalNhCRJd5bVyjgpNGv01hwRd2mAa
  > ********************************************

  Secret: VABoAGkAcwAgAGkAcwAgAGEAIABzAGUAYwByAGUAdAA=
  
> dotnet run FromBase64 -d VABoAGkAcwAgAGkAcwAgAGEAIABzAGUAYwByAGUAdAA=

Original text: This is a secret
```

## Security.Secrets.ShamirSecretShare

Split a secret piece of information into x parts, requiring y pieces to obtain the original message. 
For example, you may have a password for an operation but require *any* 3 of 5 particular members of staff to ok it.

## Security.Crypto.SymmetricCipher

Convenience wrapper to use BouncyCastle GCM block cipher.
