256 Constant RANGE

: inc-char-count ( a b -- )
                 \ input:
                 \   address of char counts
                 \   character (byte)
                 \ side-effects:
                 \   increases char counter for a given char
  cells +
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

\ could we use erase here?
: zero-char-counts ( a -- )
  RANGE 0 u+do
    0 over i cells + !
  loop
  drop ;

variable input-length
variable input-address

S" 1234567890abcdefghijklmnopqrstuvwxyzzz!"
input-length !
input-address !

create char-counts RANGE cells allot

: dump-char-counts ( -- )
  char-counts RANGE cells dump ;

: dump-input ( -- )
  input-address input-length dump ;

char-counts zero-char-counts

char-counts
input-address @
input-length @
count-chars

dump-char-counts
.s cr
