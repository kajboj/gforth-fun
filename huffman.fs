256 Constant RANGE
cell 1 chars + Constant CHAR_COUNT_CELL_SIZE

: char-count-cells ( n -- n )
  CHAR_COUNT_CELL_SIZE * ;

: inc-char-count ( a b -- )
                 \ input:
                 \   address of char counts
                 \   character (byte)
                 \ side-effects:
                 \   increases char counter for a given char
  char-count-cells +
  1 swap
  +! ;

: count-chars ( a1 a2 u2 -- )
              \ input:
              \   address of char counts
              \   address of the string
              \   length of the string
              \ side-effects:
              \   updates char counts based on string
  0 u+do      \ a1 a2
    2dup      \ a1 a2 a1 a2
    c@        \ a1 a2 a1 b
    inc-char-count
    1+
  loop
  2drop ;

: init-char-counts ( a -- )
  RANGE 0 u+do
    dup 0 swap !
    dup cell+ i swap c!
    1 char-count-cells +
  loop
  drop ;

variable input-length
variable input-address

S" 1234567890abcdefghijklmnopqrstuvwxyzzz!"
input-length !
input-address !

create char-counts RANGE cells allot

char-counts init-char-counts

  char-counts
  input-address @
  input-length @
count-chars

char-counts RANGE char-count-cells dump
.s cr
