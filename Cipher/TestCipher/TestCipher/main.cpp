#include <iostream>

using namespace std;

extern "C" int someFunction();
extern "C" void encryptCaesarAsm(char sentence[],int key,int size);
extern "C" void decryptCaesarAsm(char sentence[], int key, int size);
extern "C" void encryptVigenereAsm(char sentence[], char keyword[], long long int sizeSentence, long long int sizeKeyword);
extern "C" void testAVX(char sentence[],int key);
extern "C" void caesar(char sentence[], int key, int size);


int main() {

	int key = 1;
	char sentence[] = "BCDEFGHI";
	int sizeSentence = 8;
	char keyword[] = "HASLO";
	int sizeKeyword = 5;

	caesar(sentence, key, sizeSentence);
	//encryptCaesarAsm(sentence, key, sizeSentence);
    //cout << sentence << endl;
	//testAVX(sentence,key);
	//encryptVigenereAsm(sentence, keyword, sizeSentence, sizeKeyword);
	cout << sentence << endl;
	/*encryptCaesarAsm(sentence, key, size);
	cout << sentence << endl;
	decryptCaesarAsm(sentence, key, size);*/
	//cout << sentence << endl;
	//cout << "The result is: " << someFunction() << endl;
	return 0;
}