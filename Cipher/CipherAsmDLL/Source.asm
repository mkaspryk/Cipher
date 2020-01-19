.code

;........................................
;WITH SIMD ..............................
;........................................

encryptCaesarAsmSIMD proc
; Stack Organization (Global and local variables are stored on the stack)
push rbp                                 ; Decreases rsp and places rbp at the new memory location pointed to by rsp
mov rbp,rsp                              ; Copies register rsp to register rbp
; Calling Convention
mov qword ptr[rbp-48],rcx                ; Copies rcx(sentence) register to ptr [rbp-48] (memory address) register
mov qword ptr[rbp-8],rdx                 ; Copies rdx(key) register to ptr [rbp-8] (memory address)
mov qword ptr[rbp-16],r8                 ; Copies r8(size) register to ptr [rbp-16] (memory address)
; WHILE LOOP
mov qword ptr[rbp-24],0                  ; Loads 0 to [rbp-24] register (stores ptr to sentence elements)
vpbroadcastb xmm2,byte ptr[rbp-8]        ; Broadcasts a 64-bit value from a ptr[rbp-8] to all quad-words in the 128-bit register xmm2.
WHILE_LOOP:
mov rbx, qword ptr[rbp-24]               ; Copies register ptr [rbp-24] to register rbx
cmp rbx, qword ptr[rbp-16]               ; Sets flags corresponding to whether ptr [rbp-16] is less than, equal to, or greater than rbx
jge END_FUN                              ; If rbx is equal or greater of ptr [rbp-16] jump to label END_FUN
mov rax,qword ptr[rbp-24]                ; Copies ptr [rbp-24] (stores ptr to sentence elements) to temporary register rax
mov rbx,qword ptr[rbp-48]                ; Copies ptr sentence to temporary register rbx
add rbx,rax                              ; Adds rax register to rbx register (ptr to sentence element)
mov r15,rbx                              ; Copies rbx to r15
vpaddb xmm0, xmm2,byte ptr[r15]          ; Adds vector xmm2 to value from ptr[r15] and store in xmm0 register
movq qword ptr[r15],xmm0                 ; Copies xmm0 vector value to ptr[r15] register (sentence)
; FOR LOOP
mov rax, qword ptr [rbp-24]              ; Copies (ptr sentence index) ptr[rbp-24] register to temporary register rax
mov qword ptr [rbp-32], rax              ; Copies rax register to ptr [rbp-32] (ptr index)
FOR_LOOP:
mov rax, qword ptr [rbp-24]              ; Copies (ptr sentence index) to temporary register rax
add rax, 7                               ; Adds 7 to register rax value
cmp qword ptr [rbp-32], rax              ; Sets flags corresponding to whether rax is less than, equal to, or greater than ptr [rbp-32]
jg TO_WHILE                              ; If ptr [rbp-32] is greater of rax jump to label TO_WHILE
mov rbx, qword ptr [rbp-32]              ; Copies ptr [rbp-32] (ptr index for loop) to temporary register rbx
mov rax, qword ptr [rbp-48]              ; Copies ptr [rbp-48](sentence) to temporary register rax
add rax, rbx                             ; Adds value from rbx to register rax (sentence)
movzx eax, byte ptr[rax]                 ; Copies with zero-extend value from ptr[rax] to eax(32-bit) register
cmp al, 90                               ; Sets flags corresponding to whether al is less than, equal to, or greater than 90 value
jle INCREMENT_FOR_LOOP                   ; If al is less or equal of 90 'Z letter' value jump to label INCREMENT_FOR_LOOP
mov rbx, qword ptr [rbp-32]              ; Copies ptr [rbp-32] (ptr index for loop) to temporary register rbx
mov rax, qword ptr [rbp-48]              ; Copies ptr [rbp-48](sentence) to temporary register rax
add rax, rbx                             ; Adds value from rbx to register rax (sentence)
movzx eax, byte ptr[rax]                 ; Copies with zero-extend value from ptr[rax] to eax(32-bit) register
movsx eax, al                            ; Copies with Sign-Extension al (8-bit register) to eax (32-bit) register
sub eax, 91                              ; Substracts from eax register value 91 "(Z letter)-1"
cdqe                                     ; Converts dword to qword (32->64bit)
mov qword ptr [rbp-40], rax              ; Copies rax to ptr [rbp-40]
mov rax, qword ptr [rbp-40]              ; Copies ptr [rbp-40] to rax
lea edi, [rax+65]                        ; Loads effective address from [rax+65] to edi
mov rbx, qword ptr [rbp-32]              ; Copies ptr [rbp-32] (ptr index for loop) to temporary register rbx
mov rax, qword ptr [rbp-48]              ; Copies ptr [rbp-48](sentence) to temporary register rax
add rax, rbx                             ; Adds value from rbx to register rax (sentence)
mov ebx, edi                             ; Copies edi(effective address) register to ebx
mov byte ptr[rax], bl                    ; Copies bl (1-byte register) to element in ptr [rax] register
INCREMENT_FOR_LOOP:                      ; Increments the index of for loop
add qword ptr [rbp-32], 1                ; Adds one to ptr [rbp-32]
jmp FOR_LOOP                             ; Jumps to label FOR_LOOP
TO_WHILE:                                ; Label increments the ptr of index sentence (8 bytes)
add qword ptr[rbp-24],8                  ; Adds 8 value to ptr [rbp-24]
jmp WHILE_LOOP                           ; Jumps to WHILE_LOOP
END_FUN:                                 ; END_FUN label (end of function)
; End of Stack Organization
nop                                      ; Do nothing (standard)
pop rbp                                  ; Copies the value stored at the location pointed to by rsp to rbp and increases rsp.
ret                                      ; Pops the return address off the stack and jump unconditionally to this address.
encryptCaesarAsmSIMD endp

decryptCaesarAsmSIMD proc
; Stack Organization (Global and local variables are stored on the stack)
push rbp                                 ; Decreases rsp and places rbp at the new memory location pointed to by rsp
mov rbp,rsp                              ; Copies register rsp to register rbp
; Calling Convention
mov qword ptr[rbp-48],rcx                ; Copies rcx(sentence) register to ptr [rbp-48] (memory address) register
mov qword ptr[rbp-8],rdx                 ; Copies rdx(key) register to ptr [rbp-8] (memory address)
mov qword ptr[rbp-16],r8                 ; Copies r8(size) register to ptr [rbp-16] (memory address)
; WHILE LOOP
mov qword ptr[rbp-24],0                  ; Loads 0 to [rbp-24] register (stores ptr to sentence elements)
neg qword ptr[rbp-8]                     ; Negation of value from ptr[rbp-8]
vpbroadcastb xmm2,byte ptr[rbp-8]        ; Broadcasts a 64-bit value from a ptr[rbp-8] to all quad-words in the 128-bit register xmm2.
WHILE_LOOP:
mov rbx, qword ptr[rbp-24]               ; Copies register ptr [rbp-24] to register rbx
cmp rbx, qword ptr[rbp-16]               ; Sets flags corresponding to whether ptr [rbp-16] is less than, equal to, or greater than rbx
jge END_FUN                              ; If rbx is equal or greater of ptr [rbp-16] jump to label END_FUN
mov rax,qword ptr[rbp-24]                ; Copies ptr [rbp-24] (stores ptr to sentence elements) to temporary register rax
mov rbx,qword ptr[rbp-48]                ; Copies ptr sentence to temporary register rbx
add rbx,rax                              ; Adds rax register to rbx register (ptr to sentence element)
mov r15,rbx                              ; Copies rbx to r15
vpaddb xmm0, xmm2,byte ptr[r15]          ; Adds vector xmm2 to value from ptr[r15] and store in xmm0 register
movq qword ptr[r15],xmm0                 ; Copies xmm0 vector value to ptr[r15] register (sentence)
; FOR LOOP
mov rax, qword ptr [rbp-24]              ; Copies (ptr sentence index) ptr[rbp-24] register to temporary register rax
mov qword ptr [rbp-32], rax              ; Copies rax register to ptr [rbp-32] (ptr index)
FOR_LOOP:
mov rax, qword ptr [rbp-24]              ; Copies (ptr sentence index) to temporary register rax
add rax, 7                               ; Adds 7 to register rax value
cmp qword ptr [rbp-32], rax              ; Sets flags corresponding to whether rbx is less than, equal to, or greater than ptr [rbp-32]
jg TO_WHILE                              ; If ptr [rbp-32] is greater of rax jump to label TO_WHILE
mov rbx, qword ptr [rbp-32]              ; Copies ptr [rbp-32] (ptr index for loop) to temporary register rbx
mov rax, qword ptr [rbp-48]              ; Copies ptr [rbp-48](sentence) to temporary register rax
add rax, rbx                             ; Adds value from rbx to register rax (sentence)
movzx eax, byte ptr[rax]                 ; Copies with zero-extend value from ptr[rax] to eax(32-bit) register
cmp al, 64                               ; Sets flags corresponding to whether al is less than, equal to, or greater than 64 value
jg INCREMENT_LOOP                        ; If al is greater of 64 '65 is A letter' value jump to label INCREMENT_FOR_LOOP
mov rbx, qword ptr [rbp-32]              ; Copies ptr [rbp-32] (ptr index for loop) to temporary register rbx
mov rax, qword ptr [rbp-48]              ; Copies ptr [rbp-48](sentence) to temporary register rax
add rax, rbx                             ; Adds value from rbx to register rax (sentence)
movzx eax, byte ptr [rax]                ; Copies with zero-extend value from ptr[rax] to eax(32-bit) register
movsx eax, al                            ; Copies with Sign-Extension al (8-bit register) to eax (32-bit) register
mov ebx, 64                              ; Copies 64 value to ebx register
sub ebx, eax                             ; Substracts from (('A'- 1)=64) ebx register the eax register (sentence element)
mov eax, ebx                             ; Copies ebx to eax temporary register
cdqe                                     ; Converts dword to qword (32->64bit)
mov qword ptr [rbp-40], rax              ; Copies rax to ptr [rbp-40]
mov rax, qword ptr [rbp-40]              ; Copies ptr [rbp-40] to rax
mov ebx, 90                              ; Copies value 90 to ebx register
mov edi, ebx                             ; Copies ebx to edi
sub edi, eax                             ; Substracts from edi register the eax
mov rbx, qword ptr [rbp-32]              ; Copies ptr [rbp-32] (ptr index for loop) to rbx
mov rax, qword ptr [rbp-48]              ; Copies ptr [rbp-48](sentence) to temporary register rax
add rax, rbx                             ; Adds value from rbx to register rax (sentence)
mov ebx, edi                             ; Copies edi to rax
mov byte ptr [rax], bl                   ; Copies from one byte register value to ptr [rax] (element)
mov rbx, qword ptr [rbp-32]              ; Copies ptr [rbp-32] (ptr index for loop) to rbx
mov rax, qword ptr [rbp-48]              ; Copies ptr [rbp-48](sentence) to temporary register rax
add rax, rbx                             ; Adds value from rbx to register rax (sentence)
movzx eax, byte ptr [rax]                ; Copies with zero-extned byte ptr [rax] to eax (32-bit) register
cmp al, 58                               ; Sets flags corresponding to whether al is less than, equal to, or greater than 58 (ASCII ':') value
jne INCREMENT_LOOP                       ; Jumps to INCREMENT_LOOP if al is not equal to ':' (58)
mov rbx, qword ptr [rbp-32]              ; Copies ptr [rbp-32] (ptr index for loop) to rbx
mov rax, qword ptr [rbp-48]              ; Copies ptr [rbp-48](sentence) to temporary register rax
add rax, rbx                             ; Adds value from rbx to register rax (sentence)
mov byte ptr [rax], 32                   ; Loads 32 value 'space' to byte ptr[rax]
INCREMENT_LOOP:                          ; Increments the index of for loop
add qword ptr [rbp-32], 1                ; Adds one to ptr [rbp-32]
jmp FOR_LOOP                             ; Jumps to label FOR_LOOP
TO_WHILE:                                ; Label increments the ptr of index sentence (8 bytes)
add qword ptr[rbp-24],8                  ; Adds 8 value to ptr [rbp-24]
jmp WHILE_LOOP                           ; Jumps to WHILE_LOOP
END_FUN:                                 ; END_FUN label (end of function)
; End of Stack Organization
nop                                      ; Do nothing (standard)
pop rbp                                  ; Copies the value stored at the location pointed to by rsp to rbp and increases rsp
ret                                      ; Pops the return address off the stack and jump unconditionally to this address
decryptCaesarAsmSIMD endp

;Vigenere Cipher
encryptVigenereAsmSIMD proc
; Stack Organization (Global and local variables are stored on the stack)
push rbp                                 ; Decreases rsp and places rbp at the new memory location pointed to by rsp
mov rbp,rsp                              ; Copies register rsp to register rbp
; Calling Convention
mov qword ptr[rbp-8],rcx                 ; Copies rcx(sentence) register to ptr [rbp-8] (memory address) register
mov qword ptr[rbp-16],rdx                ; Copies rdx(keyword) register to ptr [rbp-16] (memory address)
mov qword ptr[rbp-24],r8                 ; Copies r8(size sentence) register to ptr [rbp-24] (memory address)
; WHILE LOOP
mov qword ptr[rbp-32],0                  ; Loads 0 to [rbp-32] register (stores ptr to sentence elements)
mov r15,65                               ; Loads 65 to r15 register
movq xmm0,r15                            ; Copies r15 to xmm0 128 bit register 
vpbroadcastb xmm1,xmm0                   ; Broadcasts a 64-bit value from a xmm0 to all quad-words in the 128-bit register xmm1.
WHILE_LOOP:
mov rbx, qword ptr[rbp-32]               ; Copies register ptr [rbp-32] to register rbx 
cmp rbx, qword ptr[rbp-24]               ; Sets flags corresponding to whether ptr [rbp-24](size sentence) is less than, equal to, or greater than rbx
jge END_FUN                              ; If rbx is equal or greater of ptr [rbp-24] jump to label END_FUN
mov rax, qword ptr[rbp-32]               ; Copies register ptr [rbp-32] to register rax
mov rbx, qword ptr[rbp-8]                ; Copies register ptr [rbp-8] to register rbx
add rbx,rax                              ; Adds rax register to rbx register (ptr to sentence element)
mov r15,rbx                              ; Copies rbx to r15
movq xmm2, qword ptr[r15]                ; Copies ptr to quad word from r15 to xmm2 register
mov rbx, qword ptr[rbp-16]               ; Copies ptr [rbp-16] to rbx temporary register
add rbx,rax                              ; Adds rax register to rbx register (ptr to sentence element)
mov r14,rbx                              ; Copies rbx to r14 register
movq xmm3, qword ptr[r14]                ; Copies ptr to quad word from r14 to xmm3 register
vpsubb xmm4,xmm3, xmm1                   ; Substracts xmm3 value from xmm1 and store in xmm4 register
vpaddb xmm5,xmm2,xmm4                    ; Adds xmm2 to value from xmm4 and store in xmm5 register
movq qword ptr[r15],xmm5                 ; Copies xmm5 vector value to ptr[r15] register (sentence)
; FOR LOOP
mov rax, qword ptr [rbp-32]              ; Copies (ptr sentence index) ptr[rbp-32] register to temporary register rax
mov qword ptr [rbp-40], rax              ; Copies rax register to ptr [rbp-40] (ptr index)
FOR_LOOP:
mov rax, qword ptr [rbp-32]              ; Copies ptr [rbp-32] (ptr sentence index) to temporary register rax
add rax, 7                               ; Adds 7 to register rax value
cmp qword ptr [rbp-40], rax              ; Sets flags corresponding to whether rbx is less than, equal to, or greater than ptr [rbp-40]
jg TO_WHILE                              ; If ptr [rbp-40] is greater of rax jump to label TO_WHILE
mov rbx, qword ptr [rbp-40]              ; Copies register ptr [rbp-40] to register rax
mov rax, qword ptr [rbp-8]               ; Copies register ptr [rbp-8] to register rbx
add rax, rbx                             ; Adds value from rbx to register rax (sentence)
movzx eax, byte ptr [rax]                ; Copies with zero-extend value from ptr[rax] to eax(32-bit) register
cmp al, 90                               ; Sets flags corresponding to whether al is less than, equal to, or greater than 90 value
jle INCREMENT_FOR_LOOP                   ; If al is less or equal of 90 'Z letter' value jump to label TO_WHILE INCREMENT_FOR_LOOP
mov rbx, qword ptr [rbp-40]              ; Copies register ptr [rbp-40] to register rax
mov rax, qword ptr [rbp-8]               ; Copies register ptr [rbp-8] to register rbx
add rax, rbx                             ; Adds value from rbx to register rax (sentence)
movzx eax, byte ptr [rax]                ; Copies with zero-extend value from ptr[rax] to eax(32-bit) register
lea edi, [rax-26]                        ; Loads effective address from [rax-26] to edi register
mov rbx, qword ptr [rbp-40]              ; Copies register ptr [rbp-40] to register rax
mov rax, qword ptr [rbp-8]               ; Copies register ptr [rbp-8] to register rbx
add rax, rbx                             ; Adds value from rbx to register rax (sentence)
mov ebx, edi                             ; Copies edi(effective address) register to ebx
mov byte ptr [rax], bl                   ; Copies bl (1-byte register) to element in ptr [rax] register
INCREMENT_FOR_LOOP:                      ; Increments the index of for loop
add qword ptr [rbp-40], 1                ; Adds one to ptr [rbp-40]
jmp FOR_LOOP                             ; Jumps to label FOR_LOOP
TO_WHILE:                                ; Label increments the ptr of index sentence (8 bytes)
add qword ptr[rbp-32],8                  ; Adds 8 value to ptr [rbp-32]
jmp WHILE_LOOP                           ; Jumps to label WHILE_LOOP
END_FUN:                                 ; END_FUN label (end of function)
nop                                      ; Do nothing (standard)
pop rbp                                  ; Copies the value stored at the location pointed to by rsp to rbp and increases rsp
ret                                      ; Pops the return address off the stack and jump unconditionally to this address
encryptVigenereAsmSIMD endp

decryptVigenereAsmSIMD proc
; Stack Organization (Global and local variables are stored on the stack)
push rbp                                 ; Decreases rsp and places rbp at the new memory location pointed to by rsp
mov rbp,rsp                              ; Copies register rsp to register rbp
mov qword ptr[rbp-8],rcx                 ; Copies rcx(sentence) register to ptr [rbp-8] (memory address) register
mov qword ptr[rbp-16],rdx                ; Copies rdx(keyword) register to ptr [rbp-16] (memory address)
mov qword ptr[rbp-24],r8                 ; Copies r8(size sentence) register to ptr [rbp-24] (memory address)
; WHILE LOOP
mov qword ptr[rbp-32],0                  ; Loads 0 to [rbp-32] register (stores ptr to sentence elements)
mov r15,65                               ; Loads 65 to r15 register
movq xmm0,r15                            ; Copies r15 to xmm0 128 bit register 
vpbroadcastb xmm1,xmm0                   ; Broadcasts a 64-bit value from a xmm0 to all quad-words in the 128-bit register xmm1
WHILE_LOOP:
mov rbx, qword ptr[rbp-32]               ; Copies register ptr [rbp-32] to register rbx 
cmp rbx, qword ptr[rbp-24]               ; Sets flags corresponding to whether ptr [rbp-24](size sentence) is less than, equal to, or greater than rbx
jge END_FUN                              ; If rbx is equal or greater of ptr [rbp-24] jump to label END_FUN
mov rax, qword ptr[rbp-32]               ; Copies register ptr [rbp-32] to register rax
mov rbx, qword ptr[rbp-8]                ; Copies register ptr [rbp-8] to register rbx
add rbx,rax                              ; Adds rax register to rbx register (ptr to sentence element)
mov r15,rbx                              ; Copies rbx to r15
movq xmm2, qword ptr[r15]                ; Copies ptr to quad word from r15 to xmm2 register
mov rbx, qword ptr[rbp-16]               ; Copies ptr [rbp-16] to rbx temporary register
add rbx,rax                              ; Adds rax register to rbx register (ptr to sentence element)
mov r14,rbx                              ; Copies rbx to r14 register
movq xmm3, qword ptr[r14]                ; Copies ptr to quad word from r14 to xmm3 register
vpsubb xmm4,xmm1,xmm3                    ; Substracts xmm1 value from xmm3 and store in xmm4 register
vpaddb xmm5,xmm2,xmm4                    ; Adds xmm2 to value from xmm4 and store in xmm5 register
movq qword ptr[r15],xmm5                 ; Copies xmm5 vector value to ptr[r15] register (sentence)
; FOR LOOP
mov rax, qword ptr [rbp-32]              ; Copies (ptr sentence index) ptr[rbp-32] register to temporary register rax
mov qword ptr [rbp-40], rax              ; Copies rax register to ptr [rbp-40] (ptr index)
FOR_LOOP:
mov rax, qword ptr [rbp-32]              ; Copies ptr [rbp-32] (ptr sentence index) to temporary register rax
add rax, 7                               ; Adds 7 to register rax value
cmp qword ptr [rbp-40], rax              ; Sets flags corresponding to whether rbx is less than, equal to, or greater than ptr [rbp-40]
jg TO_WHILE                              ; If ptr [rbp-40] is greater of rax jump to label TO_WHILE
mov rbx, qword ptr [rbp-40]              ; Copies register ptr [rbp-40] to register rax
mov rax, qword ptr [rbp-8]               ; Copies register ptr [rbp-8] to register rbx
add rax, rbx                             ; Adds value from rbx to register rax (sentence)
movzx eax, byte ptr [rax]                ; Copies with zero-extend value from ptr[rax] to eax(32-bit) register
cmp al, 64                               ; Sets flags corresponding to whether al is less than, equal to, or greater than 64 value
jg INCREMENT_FOR_LOOP                    ; If al is greater than 64 (1 -'A letter') value jump to label INCREMENT_FOR_LOOP
mov rbx, qword ptr [rbp-40]              ; Copies register ptr [rbp-40] to register rax
mov rax, qword ptr [rbp-8]               ; Copies register ptr [rbp-8] to register rbx
add rax, rbx                             ; Adds value from rbx to register rax (sentence)
movzx eax, byte ptr [rax]                ; Copies with zero-extend value from ptr[rax] to eax(32-bit) register
lea edi, [rax+26]                        ; Loads effective address from [rax+26] to edi register
mov rbx, qword ptr [rbp-40]              ; Copies register ptr [rbp-40] to register rax
mov rax, qword ptr [rbp-8]               ; Copies register ptr [rbp-8] to register rbx
add rax, rbx                             ; Adds value from rbx to register rax (sentence)
mov ebx, edi                             ; Copies edi(effective address) register to ebx
mov byte ptr [rax], bl                   ; Copies bl (1-byte register) to element in ptr [rax] register
mov rbx, qword ptr [rbp-40]              ; Copies register ptr [rbp-40] to register rax
mov rax, qword ptr [rbp-8]               ; Copies register ptr [rbp-8] to register rbx
add rax, rbx                             ; Adds value from rbx to register rax (sentence)
movzx eax, byte ptr [rax]                ; Copies with zero-extend value from ptr[rax] to eax(32-bit) register
cmp al, 58                               ; Sets flags corresponding to whether al is less than, equal to, or greater than 58 value
jne INCREMENT_FOR_LOOP                   ; If al is not equal to 58 ':' value jump to label INCREMENT_FOR_LOOP
mov rbx, qword ptr [rbp-40]              ; Copies register ptr [rbp-40] to register rax
mov rax, qword ptr [rbp-8]               ; Copies register ptr [rbp-8] to register rbx
add rax, rbx                             ; Adds value from rbx to register rax (sentence)
mov byte ptr [rax], 32                   ; Copies value 32 'space' to sentence (element) 
INCREMENT_FOR_LOOP:
add qword ptr [rbp-40], 1                ; Adds one to ptr [rbp-40]
jmp FOR_LOOP                             ; Jumps to label FOR_LOOP
TO_WHILE:                                ; Label increments the ptr of index sentence (8 bytes)
add qword ptr[rbp-32],8                  ; Adds 8 value to ptr [rbp-32]
jmp WHILE_LOOP                           ; Jumps to label WHILE_LOOP
END_FUN:                                 ; END_FUN label (end of function)
nop                                      ; Do nothing (standard)
pop rbp                                  ; Copies the value stored at the location pointed to by rsp to rbp and increases rsp
ret                                      ; Pops the return address off the stack and jump unconditionally to this address
decryptVigenereAsmSIMD endp

;..............................................................
; WITHOUT SIMD ................................................
;..............................................................

encryptCaesarAsm proc
push rbp
mov rbp,rsp
mov qword ptr[rbp-24], rcx               ; Copies rcx(sentence) register to ptr [rbp-24] (memory address) register
mov qword ptr[rbp-32], rdx               ; Copies rdx(key) register to ptr [rbp-32] (memory address)
mov qword ptr[rbp-40], r8                ; Copies r8(size sentence) register to ptr [rbp-40] (memory address)
; FOR LOOP
mov qword ptr[rbp-8], 0                  ; Loads 0 to [rbp-24] register (stores ptr to sentence elements)
FOR_LOOP:
mov rax,qword ptr[rbp-8]
cmp rax,qword ptr[rbp-40]                ; Sets flags corresponding to whether rax is less than, equal to, or greater than ptr[rbp-40]
jge END_FUN                              ; If rax is greater or equal to ptr[rbp-40] jump to label END_FUN
mov rdx,qword ptr[rbp-8]
mov rax,qword ptr[rbp-24]
add rax, rdx
movzx eax, byte ptr[rax]
cmp al, 64                               ; Sets flags corresponding to whether al is less than, equal to, or greater than 64 ('A'-1)
jle INCREMENT_LOOP                       ; If al is less or equal to 64 jump to label INCREMENT_LOOP
mov rdx,qword ptr[rbp-8]
mov rax, qword ptr[rbp-24]
add rax, rdx
movzx eax, byte ptr[rax]
cmp al, 90                               ; Sets flags corresponding to whether al is less than, equal to, or greater than 90 value ('Z')
jg INCREMENT_LOOP                        ; If al is greater than 90 jump to label INCREMENT_LOOP
mov byte ptr[rbp-9], 65
mov byte ptr[rbp-10], 90
mov rdx, qword ptr[rbp-8]
mov rax, qword ptr[rbp-24]
add rax, rdx
movzx eax, byte ptr[rax]
movsx rdx, al
mov rax, qword ptr[rbp-32]
add rdx, rax
movsx rax, byte ptr[rbp-10]
cmp rdx, rax                             ; Sets flags corresponding to whether rdx is less than, equal to, or greater than rax
jg ELSE_LOOP                             ; If rdx is greater than 90 jump to label ELSE_LOOP
mov rdx, qword ptr[rbp-8]
mov rax, qword ptr[rbp-24]
add rax, rdx
movzx eax, byte ptr[rax]
mov edx, eax
mov rax, qword ptr[rbp-32]
lea ecx, [rdx+rax]
mov rdx, qword ptr[rbp-8]
mov rax, qword ptr[rbp-24]
add rax, rdx
mov edx, ecx
mov byte ptr[rax], dl
jmp INCREMENT_LOOP
ELSE_LOOP:
mov rdx, qword ptr[rbp-8]
mov rax, qword ptr[rbp-24]
add rax, rdx
movzx eax, byte ptr[rax]
mov edx, eax
mov rax, qword ptr[rbp-32]
add eax, edx
lea ecx, [rax-26]
mov rdx, qword ptr[rbp-8]
mov rax, qword ptr[rbp-24]
add rax, rdx
mov edx, ecx
mov byte ptr[rax], dl
INCREMENT_LOOP:
add qword ptr[rbp-8], 1
jmp FOR_LOOP
END_FUN:
nop
pop rbp
ret
encryptCaesarAsm endp

decryptCaesarAsm proc
push rbp
mov rbp, rsp
mov qword ptr[rbp-40], rcx                ; Copies rcx(sentence) register to ptr [rbp-40] (memory address) register
mov qword ptr[rbp-48], rdx                ; Copies rdx(key) register to ptr [rbp-48] (memory address)
mov qword ptr[rbp-56], r8                 ; Copies r8(size) register to ptr [rbp-16] (memory address)
mov eax, 26
sub rax, qword ptr[rbp-48]
mov qword ptr[rbp-16], rax
mov qword ptr[rbp-8], 0
FOR_LOOP:
mov rax, qword ptr[rbp-8]
cmp rax, qword ptr[rbp-56]                ; Sets flags corresponding to whether rax is less than, equal to, or greater than ptr[rbp-56]
jge END_FUN                               ; If rax is greater or equal to ptr[rbp-56] jump to label END_FUN
mov rdx, qword ptr[rbp-8]
mov rax, qword ptr[rbp-40]
add rax, rdx
movzx eax, byte ptr[rax]
cmp al, 64                                ; Sets flags corresponding to whether al is less than, equal to, or greater than 64 ('A'-1)
jle INCREMENT_LOOP                        ; If al is less or equal to 64 jump to label INCREMENT_LOOP
mov rdx, qword ptr[rbp-8]
mov rax, qword ptr[rbp-40]
add rax, rdx
movzx eax, byte ptr[rax]
cmp al, 90                                ; Sets flags corresponding to whether al is less than, equal to, or greater than 90 value ('Z')
jg INCREMENT_LOOP                         ; If al is greater than 90 jump to label INCREMENT_LOOP
mov byte ptr[rbp-17], 65
mov byte ptr[rbp-18], 90
mov rdx, qword ptr[rbp-8]
mov rax, qword ptr[rbp-40]
add rax, rdx
movzx eax, byte ptr[rax]
movsx rdx, al
mov rax, qword ptr[rbp-16]
add rdx, rax
movsx rax, byte ptr[rbp-18]
cmp rdx, rax                              ; Sets flags corresponding to whether rdx is less than, equal to, or greater than rax
jg ELSE_LOOP                              ; If rdx is greater than 90 jump to label ELSE_LOOP
mov rdx, qword ptr[rbp-8]
mov rax, qword ptr[rbp-40]
add rax, rdx
movzx eax, byte ptr[rax]
mov edx, eax
mov rax, qword ptr[rbp-16]
lea ecx, [rdx+rax]
mov rdx, qword ptr[rbp-8]
mov rax, qword ptr[rbp-40]
add rax, rdx
mov edx, ecx
mov byte ptr[rax], dl
jmp INCREMENT_LOOP
ELSE_LOOP:
mov rdx, qword ptr[rbp-8]
mov rax, qword ptr[rbp-40]
add rax, rdx
movzx eax, byte ptr[rax]
mov edx, eax
mov rax, qword ptr[rbp-16]
add eax, edx
lea ecx, [rax-26]
mov rdx, qword ptr[rbp-8]
mov rax, qword ptr[rbp-40]
add rax, rdx
mov edx, ecx
mov byte ptr[rax], dl
INCREMENT_LOOP:
add qword ptr[rbp-8], 1
jmp FOR_LOOP
END_FUN:
nop
pop rbp
ret
decryptCaesarAsm endp

;Vigenere Cipher
encryptVigenereAsm proc
push rbp
mov rbp, rsp
mov qword ptr [rbp-24], rcx                ; Copies rcx(sentence) register to ptr [rbp-24] (memory address) register
mov qword ptr [rbp-32], rdx                ; Copies rdx(keyword) register to ptr [rbp-32] (memory address)
mov qword ptr [rbp-40], r8                 ; Copies r8(size sentene) register to ptr [rbp-40] (memory address)
mov qword ptr [rbp-48], r9                 ; Copies r9(size keyword) register to ptr [rbp-48] (memory address)
;FOR LOOP
mov qword ptr [rbp-8], 0
mov dword ptr [rbp-12], 0
FOR_LOOP:
mov eax, dword ptr [rbp-12]
cmp qword ptr [rbp-40], rax                ; Sets flags corresponding to whether rax is less than, equal to, or greater than ptr[rbp-40]
jle END_FUN                                ; If rax is greater or equal to ptr[rbp-40] jump to label END_FUN
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
movzx eax, byte ptr [rax]
cmp al, 64                                 ; Sets flags corresponding to whether al is less than, equal to, or greater than 64 ('A'-1)
jle IF_EQUAL_ITER                          ; If al is less or equal to 64 jump to IF_EQUAL_ITER
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
movzx eax, byte ptr [rax]
cmp al, 90                                 ; Sets flags corresponding to whether al is less than, equal to, or greater than 90 value ('Z')
jg IF_EQUAL_ITER                           ; If al is greater than 90 jump to label IF_EQUAL_ITER
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
movzx eax, byte ptr [rax]
mov ecx, eax
mov rdx, qword ptr [rbp-8]
mov rax, qword ptr [rbp-32]
add rax, rdx
movzx eax, byte ptr [rax]
add eax, ecx
lea ecx, [rax-65]
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
mov edx, ecx
mov byte ptr [rax], dl
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
movzx eax, byte ptr [rax]
cmp al, 90                                 ; Sets flags corresponding to whether al is less than, equal to, or greater than 90 value ('Z')
jle IF_EQUAL_ITER                          ; If al is less or equal to 64 jump to IF_EQUAL_ITER
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
movzx eax, byte ptr [rax]
lea ecx, [rax-26]
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
mov edx, ecx
mov byte ptr [rax], dl
IF_EQUAL_ITER:
mov rax, qword ptr [rbp-8]
add rax, 1
cmp qword ptr [rbp-48], rax                ; Sets flags corresponding to whether ptr [rbp-48] value is less than, equal to, or greater than rax
jne ELSE_LOOP_ITER                         ; If ptr [rbp-48] value is not equal to rax jump to ELSE_LOOP_ITER
mov qword ptr [rbp-8], 0
jmp INCREMENT_LOOP
ELSE_LOOP_ITER:
add qword ptr [rbp-8], 1
INCREMENT_LOOP:
add dword ptr [rbp-12], 1
jmp FOR_LOOP
END_FUN:
nop
pop rbp
ret
encryptVigenereAsm endp

decryptVigenereAsm proc
push rbp
mov rbp, rsp
mov qword ptr [rbp-24], rcx                ; Copies rcx(sentence) register to ptr [rbp-24] (memory address) register
mov qword ptr [rbp-32], rdx                ; Copies rdx(keyword) register to ptr [rbp-32] (memory address)
mov qword ptr [rbp-40], r8                 ; Copies r8(size sentene) register to ptr [rbp-40] (memory address)
mov qword ptr [rbp-48], r9                 ; Copies r9(size keyword) register to ptr [rbp-48] (memory address)
mov qword ptr [rbp-8], 0
mov dword ptr [rbp-12], 0
FOR_LOOP:
mov eax, dword ptr [rbp-12]
cmp qword ptr [rbp-40], rax                ; Sets flags corresponding to whether rax is less than, equal to, or greater than ptr[rbp-40]
jle END_FUN                                ; If rax is greater or equal to ptr[rbp-40] jump to label END_FUN
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
movzx eax, byte ptr [rax]
cmp al, 64                                 ; Sets flags corresponding to whether al is less than, equal to, or greater than 64 ('A'- 1)
jle IF_EQUAL_ITER                          ; If al is less or equal to 64 jump to IF_EQUAL_ITER
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
movzx eax, byte ptr [rax]
cmp al, 90                                 ; Sets flags corresponding to whether al is less than, equal to, or greater than 90 value ('Z')
jg IF_EQUAL_ITER                           ; If al is greater than 90 jump to label IF_EQUAL_ITER
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
movzx edx, byte ptr [rax]
mov rcx, qword ptr [rbp-8]
mov rax, qword ptr [rbp-32]
add rax, rcx
movzx eax, byte ptr [rax]
cmp dl, al                                 ; Sets flags corresponding to whether al is less than, equal to, or greater than bl
jl ELSE_LOOP                               ; If dl is less than al jump to label ELSE_LOOP
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
movzx eax, byte ptr [rax]
mov ecx, eax
mov rdx, qword ptr [rbp-8]
mov rax, qword ptr [rbp-32]
add rax, rdx
movzx eax, byte ptr [rax]
mov edx, eax
mov eax, ecx
sub eax, edx
lea ecx, [rax+65]
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
mov edx, ecx
mov byte ptr [rax], dl
jmp IF_EQUAL_ITER
ELSE_LOOP:
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
movzx eax, byte ptr [rax]
mov ecx, eax
mov rdx, qword ptr [rbp-8]
mov rax, qword ptr [rbp-32]
add rax, rdx
movzx eax, byte ptr [rax]
mov edx, eax
mov eax, ecx
sub eax, edx
lea ecx, [rax+91]
mov edx, dword ptr [rbp-12]
mov rax, qword ptr [rbp-24]
add rax, rdx
mov edx, ecx
mov byte ptr [rax], dl
IF_EQUAL_ITER:
mov rax, qword ptr [rbp-8]
add rax, 1
cmp qword ptr [rbp-48], rax                ; Sets flags corresponding to whether ptr [rbp-48] value is less than, equal to, or greater than rax
jne ELSE_LOOP_ITER                         ; If ptr [rbp-48] value is not equal to rax jump to ELSE_LOOP_ITER
mov qword ptr [rbp-8], 0
jmp INCREMENT_LOOP
ELSE_LOOP_ITER:
add qword ptr [rbp-8], 1
INCREMENT_LOOP:
add dword ptr [rbp-12], 1
jmp FOR_LOOP
END_FUN:
nop
pop rbp
ret
decryptVigenereAsm endp

END