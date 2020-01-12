#include "Caesar.h"

//--------------------------------------------------------

Caesar::Caesar(){}

Caesar::Caesar(std::string sentence1, int key1) :key(key1),orginalSentence(sentence1){}

Caesar::~Caesar(){}

//--------------------------------------------------------

void Caesar::setKey(int key1) {key = key1;}

 int Caesar::getKey() {return key;}

//--------------------------------------------------------

void Caesar::setOrginalSentence(std::string sentence1) {orginalSentence = sentence1;}

std::string Caesar::getOrginalSentence() {return orginalSentence;}

//--------------------------------------------------------

void Caesar::setEncryptedSentence(std::string sentence1) {encryptedSentence = sentence1;}

std::string Caesar::getEncryptedSentence() {return encryptedSentence;}

//--------------------------------------------------------

void Caesar::setDecryptedSentence(std::string sentence1) {decryptedSentence = sentence1;}

std::string Caesar::getDecryptedSentence() {return decryptedSentence;}

//--------------------------------------------------------

void Caesar::encrypt() {
	int tmp;
	char s1, s2;
	if (!(key >= 0 && key <= 26))
		std::cout << "Niepoprawny klucz !!!" << std::endl;
	else {
		encryptedSentence = orginalSentence;
		for (int i = 0; i < encryptedSentence.size(); i++) {
			tmp = checkSign(encryptedSentence[i]);
			if (tmp == 0) {
				s1 = 'A'; s2 = 'Z';
				if (encryptedSentence[i] + key <= s2)
					encryptedSentence[i] += key;
				else
					encryptedSentence[i] = encryptedSentence[i] + key - 26;
			}
		}
	}
}

void Caesar::decrypt() {
	int tmp;
	char s1, s2;
	if (!(key >= 0 && key <= 26))
		std::cout << "Niepoprawny klucz !!!" << std::endl;
	else {
		decryptedSentence = orginalSentence;
		int tmpKey = 26 - key;
		for (int i = 0; i < decryptedSentence.size(); i++) {
			tmp = checkSign(decryptedSentence[i]);
			if (tmp == 0) {
				s1 = 'A'; s2 = 'Z';
				if (decryptedSentence[i] + tmpKey <= s2)
					decryptedSentence[i] += tmpKey;
				else
					decryptedSentence[i] = decryptedSentence[i] + tmpKey - 26;
			}
		}
	}
}

int Caesar::checkSign(char sign) {
	if (sign >= 'A'&&sign <= 'Z')
		return 0;
	else
		return 1;
}

//--------------------------------------------------------