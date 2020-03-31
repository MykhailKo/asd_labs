#ifndef MYSTRING_H_
#define MYSTRING_H_

#include <iostream>
using namespace std;

class MyString {
public:
	MyString(char * str);
	MyString(MyString &other);
	MyString();
	virtual ~MyString();
	int getLength();
	string getValue();
	MyString operator +(MyString str);
	MyString operator -(char subst);

private:
	char * _string;
};

#endif /* MYSTRING_H_ */
