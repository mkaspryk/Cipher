// CipherCppDLL.cpp : Defines the exported functions for the DLL.
//
#include "pch.h"
#include "framework.h"
#include "CipherCppDLL.h"
#include "CipherCppClass\Caesar.h"
#include "CipherCppClass\Caesar.cpp"
#include "CipherCppClass\Vigenere.h"
#include "CipherCppClass\Vigenere.cpp"
#include "CipherCppClass\CaesarSIMD.h"
#include "CipherCppClass\CaesarSIMD.cpp"
#include "CipherCppClass\VigenereSIMD.h"
#include "CipherCppClass\VigenereSIMD.cpp"

//..................................................
// ALL CPP DLL FUNCTIONS ...........................
//..................................................

/**
* Encrypt Caesar Cipher with SIMD instructions
*/
extern "C" CIPHERCPPDLL_API void encryptCaesarSIMD(char* sentence1, int key1, int size) {
	encryptCaesar(sentence1, key1, size);
}

/**
* Decrypt Caesar Cipher with SIMD instructions
*/
extern "C" CIPHERCPPDLL_API void decryptCaesarSIMD(char* sentence1, int key1, int size) {
	decryptCaesar(sentence1, key1, size);
}

/**
* Encrypt Vigenere Cipher with SIMD instructions
*/
extern "C" CIPHERCPPDLL_API void encryptVigenereSIMD(char *orginalSentence, char *keyword, int size) {
	encryptVigenere(orginalSentence, keyword, size);
}

/**
* Decrypt Vigenere Cipher with SIMD instructions
*/
extern "C" CIPHERCPPDLL_API void decryptVigenereSIMD(char *orginalSentence, char *keyword, int size) {
	decryptVigenere(orginalSentence, keyword, size);
}

/**
* Encrypt Caesar Cipher
*/
extern "C" CIPHERCPPDLL_API void encryptCaesar(char* sentence1, int key1, char *buf){
	Caesar C(sentence1, key1);
	C.encrypt();
	std::string str = C.getEncryptedSentence();
	strcpy(buf, str.c_str());
}

/**
* Decrypt Caesar Cipher
*/
extern "C" CIPHERCPPDLL_API void decryptCaesar(char* sentence1, int key1, char *buf) {

	Caesar C(sentence1, key1);
	C.decrypt();
	std::string str = C.getDecryptedSentence();
	strcpy(buf, str.c_str());
}

/**
* Encrypt Vigenere Cipher
*/
extern "C" CIPHERCPPDLL_API void encryptVigenere(char* sentence1, char* keyword1, char *buf) {

	Vigenere V(sentence1, keyword1);
	V.encrypt();
	std::string str = V.getEncryptedSentence();
	strcpy(buf, str.c_str());
}

/**
* Decrypt Vigenere Cipher
*/
extern "C" CIPHERCPPDLL_API void decryptVigenere(char* sentence1, char* keyword1, char *buf) {

	Vigenere V(sentence1, keyword1);
	V.decrypt();
	std::string str = V.getDecryptedSentence();
	strcpy(buf, str.c_str());
}