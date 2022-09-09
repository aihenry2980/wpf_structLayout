using UINT32 = unsigned int;
using UINT64 = unsigned long long;
using UINT8 = unsigned char;
using UINT16 = unsigned short;

typedef struct _A{
    UINT32 a:3;
    UINT32 b:7;
    UINT64  c;
    UINT32 ar[3];


} A;