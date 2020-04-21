#ifndef MYSTRING_H_
#define MYSTRING_H_

class MyString {
public:
	MyString();
	MyString(char * str);
	virtual ~MyString();
protected:
	char * _string;
};


#endif /* MYSTRING_H_ */
