#ifndef LETTERSTRING_H_
#define LETTERSTRING_H_

#include <iostream>
#include "MyString.h"

using namespace std;


class LetterString: public MyString::MyString {
public:
	LetterString();
	LetterString(char * str);
	virtual ~LetterString();
	int getLength();
	string getValue();
	string sortAlphabetical();
};


#endif
