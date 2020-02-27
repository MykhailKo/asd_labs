#ifndef TEXTY_H_
#define TEXTY_H_
#include <iostream>
#include "Stringy.h"

class Texty {
private:
	Stringy* _strings = nullptr;
	int _size = 0;
	int _digits = 0;
	int _length = 0;
public:
	Texty(Stringy*, int);
	virtual ~Texty();
	bool deleteString(int);
	char* getLongestString();
	int getLength();
	int getSize();
	Stringy* getStrings();
	double getDigitsPercentage();
};


#endif /* TEXTY_H_ */
