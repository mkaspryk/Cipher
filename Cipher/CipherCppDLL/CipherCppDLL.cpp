// CipherCppDLL.cpp : Defines the exported functions for the DLL.
//
#include "pch.h"
#include "framework.h"
#include "CipherCppDLL.h"
#include "CipherCppClass\Caesar.h"
#include "CipherCppClass\Caesar.cpp"
#include "CipherCppClass\Vigenere.h"
#include "CipherCppClass\Vigenere.cpp"

// This is the constructor of a class that has been exported.
CCipherCppDLL::CCipherCppDLL()
{
	return;
}

extern "C" CIPHERCPPDLL_API void encryptCaesar(char* sentence1, int key1, char *buf){

	Caesar C(sentence1, key1);
	C.encrypt();
	std::string str = C.getEncryptedSentence();
	strcpy(buf, str.c_str());
}

extern "C" CIPHERCPPDLL_API void decryptCaesar(char* sentence1, int key1, char *buf) {

	Caesar C(sentence1, key1);
	C.decrypt();
	std::string str = C.getDecryptedSentence();
	strcpy(buf, str.c_str());
}

extern "C" CIPHERCPPDLL_API void encryptVigenere(char* sentence1, char* keyword1, char *buf) {

	Vigenere V(sentence1, keyword1);
	V.encrypt();
	std::string str = V.getEncryptedSentence();
	strcpy(buf, str.c_str());
}

extern "C" CIPHERCPPDLL_API void decryptVigenere(char* sentence1, char* keyword1, char *buf) {

	Vigenere V(sentence1, keyword1);
	V.decrypt();
	std::string str = V.getDecryptedSentence();
	strcpy(buf, str.c_str());
}