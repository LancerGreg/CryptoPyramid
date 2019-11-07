# CryptoPyramid

          ^
         /0\
        *---*
       /1\0/1\
      *---*---*

Console program about encryption and decryption by pyramid

# Settings
# Encryption implementation

Pyramid taken for bulo concept. Having received the data as a string of bits, the stench fills the pyramid in an offensive manner.
           0123 4567 .... ....        
        -> 1000 1011 0111 0001 ->

                                  ^                       ^
                                 /0\                     /1\
                                *---*                   *---*
                               /1\2/3\                 /0\0/0\
                              *---*---*       ->      *---*---*
                             /4\5/6\7/8\             /1\0/1\1/0\
                            *---*---*---*           *---*---*---*
                           /9\./.\./.\./.\         /1\1/1\0/0\0/1\
                          *---*---*---*---*       *---*---*---*---*

On the initial version of the program, it is only possible to enter data of size X -> X = log(4,S); X Є N; S - size of data 
In future versions, the addition of zeros for the required size will be implemented

The next step is the transformation of small pyramids into one big, for such rules


                ^                         Every small pyramid has four elements
               /^\                        Their order becomes numbers from 0 to 3
              //0\\                       One pyramid has a dump that will be transformed into one of the values in either 1111 or 0000
             /*---*\                      Depending on which dump value will be changed, a change occurs
            //1\2/3\\                     As a result, when dump was transferred to 1111 or to 0000
           /*---*---*\                    The pyramid turns into an element of the next pyramid, which is ranked higher
          *---*---*---*           
         /^\*---*---*/^\                  ^             
        //0\\\1/2\3///0\\                /0\           ^
       /*---*\*---*/*---*\        ->    *---*    ->   /0\ 
      //1\2/3\\\0///1\2/3\\            /1\2/3\       *---*
     /*---*---*\•/*---*---*\          *---*---*
    *---*---*---*---*---*---*
  
The end result will be either 1 or 0
