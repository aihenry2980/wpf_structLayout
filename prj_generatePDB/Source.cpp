
using UINT32 = unsigned int;

struct aaStruct {

    
    unsigned int cccc;
    UINT32 tttt:3;
    UINT32 dddd:5;
    char bbbb;
    char rrrr[6];
    unsigned int eeee[3];
};

union aaUnion
{
    UINT32 nDW;
    unsigned char car[4];
    struct stDW
    {
        UINT32 stDWpppp : 3;
        UINT32 stDWyyyy : 6;
        UINT32 stDWzzzz : 1;
        UINT32 stDWxxxx : 22;
    };
};

struct ccStruct
{
    aaUnion aaheader;
    UINT32 aaDW;
    aaStruct aabody;
};

int main(void)
{
    aaStruct aaStrInst;
    aaUnion aaUnionInst;
    ccStruct ccStrInst;
    return 1;
}
