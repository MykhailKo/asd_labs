#ifndef STRINGY_H_
#define STRINGY_H_

class Stringy {
public:
	char* symbols = nullptr;
	Stringy(char*);
	virtual ~Stringy();
	int getLength();
	int getDigits();
};

#endif /* STRINGY_H_ */
