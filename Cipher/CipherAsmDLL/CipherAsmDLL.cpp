// CipherAsmDLL.cpp : Defines the exported functions for the DLL.
//

#include "framework.h"
#include "CipherAsmDLL.h"


// This is an example of an exported variable
CIPHERASMDLL_API int nCipherAsmDLL=0;

// This is an example of an exported function.
CIPHERASMDLL_API int fnCipherAsmDLL(void)
{
    return 0;
}

// This is the constructor of a class that has been exported.
CCipherAsmDLL::CCipherAsmDLL()
{
    return;
}
