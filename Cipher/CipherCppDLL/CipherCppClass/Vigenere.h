#pragma once
#include <iostream>
#include <algorithm>
#include <string>

class Vigenere
{
	/**
	* Field orginalSentence represents orginal sentence passed to encrypt or decrypt
	*/
	std::string orginalSentence;
	/**
	* Field encryptedSentence represents enrypted sentence
	*/
	std::string encryptedSentence;
	/**
	* Field decryptedSentence represents decrypted sentence
	*/
	std::string decryptedSentence;
	/**
	* Field keyword represents alphabetic password
	*/
	std::string keyword;

public:

	//--------------------------------------------------------

	/**
	* No-Arg Constructor
	*/
	Vigenere();
	/**
	* Main constructor which is used in program
	* sentence1 - orginal sentence passed to program
	* keyword1 - alphabetic password
	*/
	Vigenere(std::string sentence1, std::string keyword1);
	/**
	* Destructor
	*/
	~Vigenere();

	//--------------------------------------------------------

	/**
	* Set the orginal sentence
	*/
	void setOrginalSentence(std::string sentence1);
	/**
	* Get the orginal sentence
	*/
	std::string getOrginalSentence();

	//--------------------------------------------------------

	/**
	* Set the encrypted sentence
	*/
	void setEncryptedSentence(std::string sentence1);
	/**
	* Get the encrypted sentence
	*/
	std::string getEncryptedSentence();

	//--------------------------------------------------------

	/**
	* Set the decrypted sentence
	*/
	void setDecryptedSentence(std::string sentence1);
	/**
	* Get the decrypted sentence
	*/
	std::string getDecryptedSentence();

	//--------------------------------------------------------

	/**
	* Set the keyword
	*/
	void setKeyword(std::string keyword1);
	/**
	* Get the keyword
	*/
	std::string getKeyword();

	//--------------------------------------------------------

	/**
	* Encrypt orginal sentence to encrypted sentence
	*/
	void encrypt();
	/**
	* Decrypt orginal sentence to decrypted sentence
	*/
	void decrypt();
	/**
	* Decrypt orginal sentence to decrypted sentence
	*/
	std::string toUpper(std::string s);

	//--------------------------------------------------------
};

