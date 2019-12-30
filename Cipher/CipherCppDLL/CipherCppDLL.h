// The following ifdef block is the standard way of creating macros which make exporting
// from a DLL simpler. All files within this DLL are compiled with the CIPHERCPPDLL_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see
// CIPHERCPPDLL_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef CIPHERCPPDLL_EXPORTS
#define CIPHERCPPDLL_API __declspec(dllexport)
#else
#define CIPHERCPPDLL_API __declspec(dllimport)
#endif

// This class is exported from the dll
class CIPHERCPPDLL_API CCipherCppDLL {
public:
	CCipherCppDLL(void);
	// TODO: add your methods here.
};

extern "C" CIPHERCPPDLL_API void encryptCaesar(char* sentence1, int key1,char *buf);

extern "C" CIPHERCPPDLL_API void decryptCaesar(char* sentence1, int key1, char *buf);

extern "C" CIPHERCPPDLL_API void encryptVigenere(char* sentence1, char* keyword1, char *buf);

extern "C" CIPHERCPPDLL_API void decryptVigenere(char* sentence1, char* keyword1, char *buf);


//CIPHERCPPDLL_API char* _cdecl decryptCaesar(char* sentence1, int key1);