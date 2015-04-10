: assert ( f addr u -- )
         \ input:
         \   address of message
         \   length of the message
         \   result of the test as boolean flag
  rot invert
  if
    exception throw
  else
    2drop
  endif ;
