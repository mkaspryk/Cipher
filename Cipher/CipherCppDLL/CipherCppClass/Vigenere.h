#pragma once
#include <iostream>
#include <algorithm>
#include <string>

class Vigenere
{
	std::string orginalSentence;
	std::string encryptedSentence;
	std::string decryptedSentence;
	std::string keyword;
public:
	//--------------------------------------------------------

	Vigenere();

	Vigenere(std::string sentence1, std::string keyword1);

	~Vigenere();

	//--------------------------------------------------------

	void setOrginalSentence(std::string sentence1);

	std::string getOrginalSentence();

	//--------------------------------------------------------

	void setEncryptedSentence(std::string sentence1);

	std::string getEncryptedSentence();

	//--------------------------------------------------------

	void setDecryptedSentence(std::string sentence1);

	std::string getDecryptedSentence();

	//--------------------------------------------------------

	void setKeyword(std::string keyword1);

	std::string getKeyword();

	//--------------------------------------------------------

	void encrypt();

	void decrypt();

	std::string toUpper(std::string s);

	//--------------------------------------------------------
};

