
#include "MyList.h"
#include <iostream>
using namespace std;


void MyList::Add(double data){
	Node *nodeAdd = new Node(data);
	if(_head == nullptr) _head = nodeAdd;
	else _tail->next = nodeAdd;
	_tail = nodeAdd;
	_count++;
	_sum += data;
}

void MyList::RemoveEven(){
	if(_head != nullptr && _head != _tail){
		Node *curNode = _head;
		Node *nextNode = _head->next;
		while(nextNode != nullptr){
			if(nextNode->next == nullptr){
				_tail = curNode;
				_count--;
				_sum -= _tail->next->value;
				_tail->next = nullptr;
				nextNode = nullptr;
			}else {
				_count--;
				_sum -= curNode->next->value;
				curNode->next = nextNode->next;
				curNode = curNode->next;
				nextNode = curNode->next;
			}
		}
	}
}

int MyList::FindNumOfMoreThanAverage(){
	double average = _sum/_count;
	Node *curNode = _head;
	int num = 0;
	while(curNode != nullptr){
		if(curNode->value > average) num++;
		curNode = curNode->next;
	}
	return num;
}

int MyList::Count(){
	return _count;
}

double MyList::Sum(){
	return _sum;
}

void MyList::ShowList(){
	Node *curNode = _head;
	while(curNode != nullptr){
		cout << curNode->value << endl;
		curNode = curNode->next;
	}
}
