#include "dxEffectIncludes.h"
#include "alpha.h"

typedef struct
{
    float speed;
} fxVars;


cbuffer variableBuffer : register(b2)
{
    fxVars vars;
}

static const float kSmallVal = 0.001;

static const float boxes[10]={.79,.3,.9,.1,.4,.7,.2,.5,.3,.85};

bool InBound(float x, float a, float b)
{
    return (x > a && x<=b);
}


fxVertexOut vertexShader(fxShaderVerts input)
{
    fxVertexOut output;
    output.position =float4(input.position,1);
    output.normPos = input.position.xy*vec2(.5,-.5f)+vec2(.5,.5);
    output.tex1 = input.tex1*u.texSize;
    output.texMask = input.texMask;
    output.texSize = u.texSize;
    return output;
}


float4 pixelShader(fxVertexOut input) : SV_TARGET
{
    vec3 pCoord=vec3(input.normPos,0.0);
    vec4 textureRect=vec4(0.0,0.0,input.texSize);

    vec2 drawingOrigin = vec2(0.0,0.0);
    float drawingWidth = 1.0;
    float drawingHeight = 1.0;

    vec4 part = getColor( inputTex, fsTexture/input.texSize );
#ifdef PRE_MULT
    divideAlpha(part);
#endif
    vec4 texel=part;
    part.rgb /= u.nitsScale;

    if ( part.r>kSmallVal || part.g>kSmallVal ||part.b>kSmallVal || part.a>kSmallVal )
    {


        float texWidth = textureRect.z;
        float texHeight = textureRect.w;

        float textureWidth = texWidth;
        float textureHeight = texHeight;

        int index=int(fract(u.localTime*vars.speed)*10.0);
        float boxValue=boxes[index];

        float ratio1 = boxValue;//time;//0.79;//*;
        float ratio2 = 1.18-ratio1;// 0.39;
        float ratio3 = 1.48-ratio1;//0.69;
        float ratio4 = 0.99 - ratio1;//0.2;
        float ratio5 = 1.0-ratio1; //0.21;
        float ratio6 = 1.2-ratio1;//0.41;
        float ratio7 = 1.22-ratio1;//0.43;
        float ratio8 = 1.37-ratio1;//0.58;
        float ratio9 = 1.46-ratio1;//0.67;
        float ratio10 =1.3-ratio1;// 0.51;
        float ratio11 =1.45-ratio1;// 0.66;
        float ratio12 =1.04-ratio1;// 0.25;
        float ratio13 =1.08-ratio1;// 0.29;

        float left = drawingOrigin.x;
        float right = drawingOrigin.x+drawingWidth;
        float top = drawingOrigin.y;
        float bottom = drawingOrigin.y+drawingHeight;

        if( InBound(pCoord.x, left,  left+ratio1*drawingWidth) && InBound( pCoord.y,  top+ratio1*drawingHeight , bottom))
        {
            float x = textureRect.x+texWidth-fsTexture.x;
            float y = textureRect.y+(texHeight-(fsTexture.y-textureRect.y)+texHeight/4.0);
            x = InBound(x, textureRect.x, textureRect.x+texWidth)?x:fsTexture.x;
            y = InBound(y, textureRect.y, textureRect.y+texHeight)?y:texHeight-fsTexture.y;

            part = getColor( inputTex, vec2(x, y)/input.texSize );
#ifdef PRE_MULT
            divideAlpha(part);
#endif
            part.rgb /= u.nitsScale;
            int div = 120;
            float mul = float(div);
            part.r = float( int( part.r*360.0 ) / div )*mul / 360.0*1.2+ float(div)/360.0 ;
            part.g = float( int( part.g*360.0 ) / div )*mul / 360.0*.2+ float(div)/360.0 ;
            part.b = float( int( part.b*360.0 ) / div )*mul / 360.0+ float(div)/360.0 ;
        }
        else if( InBound(pCoord.x, left+ratio1*drawingWidth, right) && InBound( pCoord.y,top+ratio2*drawingHeight,bottom))
        {
            float x = fsTexture.x-texWidth/4.0;
            float y = textureRect.y+texHeight-fsTexture.y+texHeight/3.0 ;

            x = InBound(x, textureRect.x, textureRect.x+texWidth)?x:textureRect.x+texWidth-fsTexture.x;
            y = InBound(y, textureRect.y, textureRect.y+texHeight)?y:textureRect.y+texHeight-fsTexture.y;

            vec4 sum = getColor( inputTex, vec2( x, y)/input.texSize );
#ifdef PRE_MULT
            divideAlpha(sum);
#endif
            sum.rgb /= u.nitsScale;
            //vec4 sum = texture( inputTex, fsTexture );
            //Posterize
            int div = 50;
            float mul = float(div);
            sum.r = float( int( sum.r*360.0 ) / div )*mul / 360.0; //+ float(div)/360.0 ;
            sum.g = float( int( sum.g*360.0 ) / div )*mul / 360.0; //+ float(div)/360.0 ;
            sum.b = float( int( sum.b*360.0 ) / div )*mul / 360.0*1.5; //+ float(div)/360.0 ;

            part = sum;
        }
        else if( InBound(pCoord.x,left+ratio3*drawingWidth,right) && InBound( pCoord.y,top, top+ratio2*drawingHeight))
        {
            float x = 2.0 * ((fsTexture.x-textureRect.x)*1.4-2.0*textureWidth/3.0) / textureWidth - 1.0 ;//1.5
            float y = 2.0 * (textureHeight-(fsTexture.y-textureRect.y)*1.1-textureHeight/4.0) / textureHeight - 1.0 ;//1.1

            //warped in the middle
            //        x = sign( x ) * x * x;
            //        y = sign( y ) * y * y ;

            float i = (x + 1.0 )*textureWidth*.5+textureRect.x;
            float j = (y + 1.0 )*textureHeight*.5+textureRect.y;
            i  = InBound(i, textureRect.x, textureRect.x+texWidth)?i:fsTexture.x;
            j = InBound(j, textureRect.y, textureRect.y+texHeight)?j:fsTexture.y;

            part = getColor( inputTex, vec2(i,j)/input.texSize);
#ifdef PRE_MULT
            divideAlpha(part);
#endif
            part.rgb /= u.nitsScale;
            int div = 60;//Users/shirleycarter66/Downloads/Project1/picasso.frag
            float mul = float(div);
            part.r = float( int( part.r*360.0 ) / div )*mul / 360.0; //+ float(div)/360.0 ;
            part.g = float( int( part.g*360.0 ) / div )*mul / 360.0*1.5; //+ float(div)/360.0 ;
            part.b = float( int( part.b*360.0 ) / div )*mul / 360.0; //+ float(div)/360.0 ;
        }
        else if( InBound(pCoord.x,left+ratio4*drawingWidth,left+ratio3*drawingWidth) && InBound( pCoord.y,top, top+ratio5*drawingHeight))
        {
            float x = 2.0 * (textureWidth/3.0+fsTexture.x*.6-textureRect.x*.6) / textureWidth - 1.0 ;
            float y = 2.0 * (fsTexture.y*.6-textureRect.y*.6 + textureHeight/3.0) / textureHeight - 1.0 ;

            //        x = 2.0 * asin(x) / 3.1415926;
            //        y = 2.0 * asin(y) / 3.1415926;

            float i = (x + 1.0 )*textureWidth*.5+textureRect.x;
            float j = (y + 1.0 )*textureHeight*.5+textureRect.y;
            i  = InBound(i, textureRect.x, textureRect.x+texWidth)?i:fsTexture.x;
            j = InBound(j, textureRect.y, textureRect.y+texHeight)?j:fsTexture.y;

            part = getColor( inputTex, vec2(i,j)/input.texSize );
#ifdef PRE_MULT
            divideAlpha(part);
#endif
            part.rgb /= u.nitsScale;

            int div = 40;
            float mul = float(div);
            part.r = float( int( part.r*360.0 ) / div )*mul / 360.0*1.5; //+ float(div)/360.0 ;
            part.g = float( int( part.g*360.0 ) / div )*mul / 360.0*.7; //+ float(div)/360.0 ;
            part.b = float( int( part.b*360.0 ) / div )*mul / 360.0*1.5; //+ float(div)/360.0 ;
        }

        else if( InBound(pCoord.x, left, left+ratio4*drawingWidth) && InBound( pCoord.y,top, top+ratio6*drawingHeight))
        {

            float x = 2.0 * (textureWidth/2.0-fsTexture.x*.8+textureRect.x*0.8) / textureWidth - 1.0 ;
            float y = 2.0 * (fsTexture.y*.8-textureRect.y*0.8+ textureHeight/4.0) / textureHeight - 1.0 ;

            //        float r = sqrt(x*x + y*y);
            //        float phi = atan(y,x);//equivalent to atan2
            //
            //        float t = 3.1415/4.0;//mod( float( timer ), 30000.0 ) / 1000.0; //0 - 30 seconds
            //        float fac = abs( sin( t ) )*2.0 + .125;//+1.5;/// 2.0 + 1.5;
            //        r = pow( r, fac );//fac );//magnifier
            //
            //        x = r * cos( phi );
            //        y = r * sin( phi );

            float i = (x + 1.0 )*textureWidth*.5+textureRect.x;
            float j = (y + 1.0 )*textureHeight*.5+textureRect.y;

            i  = InBound(i, textureRect.x, textureRect.x+texWidth)?i:fsTexture.x;
            j = InBound(j, textureRect.y, textureRect.y+texHeight)?j:fsTexture.y;

            part = getColor( inputTex, vec2(i,j)/input.texSize );
#ifdef PRE_MULT
            divideAlpha(part);
#endif
            part.rgb /= u.nitsScale;

            int div = 60;
            float mul = float(div);
            part.r = float( int( part.r*360.0 ) / div )*mul / 360.0*1.4; //+ float(div)/360.0 ;
            part.g = float( int( part.g*360.0 ) / div )*mul / 360.0; //+ float(div)/360.0 ;
            part.b = float( int( part.b*360.0 ) / div )*mul / 360.0; //+ float(div)/360.0 ;

        }
        else if( InBound(pCoord.x,left+ratio4*drawingWidth,left+ratio7*drawingWidth) && InBound( pCoord.y,top+ratio5*drawingHeight,top+ratio6*drawingHeight))
        {

            float x = 2.0 * (fsTexture.x*1.4-textureRect.x*1.4) / textureWidth - 1.0 ;
            float y = 2.0 * (fsTexture.y*1.4-textureRect.y*1.4) / textureHeight - 1.0 ;

            //        float r = sqrt(x*x + y*y);
            //        float phi = atan(y,x);//equivalent to atan2
            //
            //        float t = 3.1415/4.0;//mod( float( timer ), 30000.0 ) / 1000.0; //0 - 30 seconds
            //        float fac = abs( sin( t ) )*2.0 + .125;//+1.5;/// 2.0 + 1.5;
            //        r = pow( r, fac );//fac );//magnifier
            //
            //        x = r * cos( phi );
            //        y = r * sin( phi );

            float i = (x + 1.0 )*textureWidth*.5+textureRect.x;
            float j = (y + 1.0 )*textureHeight*.5+textureRect.y;
            i  = InBound(i, textureRect.x, textureRect.x+texWidth)?i:fsTexture.x;
            j = InBound(j, textureRect.y, textureRect.y+texHeight)?j:fsTexture.y;
            part = getColor( inputTex, vec2(i,j)/input.texSize );
#ifdef PRE_MULT
            divideAlpha(part);
#endif
            part.rgb /= u.nitsScale;
            int div = 80;
            float mul = float(div);
            part.r = float( int( part.r*360.0 ) / div )*mul / 360.0*1.6; //+ float(div)/360.0 ;
            part.g = float( int( part.g*360.0 ) / div )*mul / 360.0*.4; //+ float(div)/360.0 ;
            part.b = float( int( part.b*360.0 ) / div )*mul / 360.0*.5; //+ float(div)/360.0 ;

        }
        else if( InBound(pCoord.x,left+ratio7*drawingWidth, left+ratio8*drawingWidth) && InBound( pCoord.y,top+ratio5*drawingHeight, top+ratio6*drawingHeight))
        {

            float x = 2.0 * 0.75*(fsTexture.x*1.0-textureRect.x) / textureWidth - 1.0 ;
            float y = 2.0 * 0.75*(fsTexture.y*1.0-textureRect.y) / textureHeight - 1.0 ;

            //        float r = sqrt(x*x + y*y);
            //        float phi = atan(y,x);//equivalent to atan2
            //
            //        float t = 3.1415/4.0;//mod( float( timer ), 30000.0 ) / 1000.0; //0 - 30 seconds
            //        float fac = abs( sin( t ) )*2.0 + .125;//+1.5;/// 2.0 + 1.5;
            //        r = pow( r, fac );//fac );//magnifier
            //
            //        x = r * cos( phi );
            //        y = r * sin( phi );

            float i = (x + 1.0 )*textureWidth*.5+textureRect.x;
            float j = (y + 1.0 )*textureHeight*.5+textureRect.y;
            i  = InBound(i, textureRect.x, textureRect.x+texWidth)?i:fsTexture.x;
            j = InBound(j, textureRect.y , textureRect.y+texHeight)?j:fsTexture.y;
            part =  getColor( inputTex, vec2(i,j)/input.texSize );
#ifdef PRE_MULT
            divideAlpha(part);
#endif
            part.rgb /= u.nitsScale;

            int div = 110;
            float mul = float(div);
            part.r = float( int( part.r*360.0 ) / div )*mul / 360.0*.9; //+ float(div)/360.0 ;
            part.g = float( int( part.g*360.0 ) / div )*mul / 360.0; //+ float(div)/360.0 ;
            part.b = float( int( part.b*360.0 ) / div )*mul / 360.0*1.4; //+ float(div)/360.0 ;

        }
        else if( InBound(pCoord.x, left+ratio8*drawingWidth, left+ratio3*drawingWidth) && InBound( pCoord.y,top+ratio5*drawingHeight,top+ratio6*drawingHeight))
        {

            float x = 2.0 * (fsTexture.x-textureRect.x ) / textureWidth - 1.0 ;
            float y = 2.0 * (fsTexture.y-textureRect.y ) / textureHeight - 1.0 ;

            //        float r = sqrt(x*x + y*y);
            //        float phi = atan(y,x);//equivalent to atan2
            //
            //        float t = 3.1415/4.0;//mod( float( timer ), 30000.0 ) / 1000.0; //0 - 30 seconds
            //        float fac = abs( sin( t ) )*2.0 + .125;//+1.5;/// 2.0 + 1.5;
            //        r = pow( r, fac );//fac );//magnifier
            //
            //        x = r * cos( phi );
            //        y = r * sin( phi );

            float i = (x + 1.0 )*textureWidth*.5+textureRect.x;
            float j = (y + 1.0 )*textureHeight*.5+textureRect.y;
            i  = InBound(i, textureRect.x, textureRect.x+texWidth)?i:fsTexture.x;
            j = InBound(j, textureRect.y , textureRect.y+texHeight)?j:fsTexture.y;
            part =  getColor( inputTex, vec2(i,j)/input.texSize );
#ifdef PRE_MULT
            divideAlpha(part);
#endif
            part.rgb /= u.nitsScale;

            int div = 65;
            float mul = float(div);
            part.r = float( int( part.r*360.0 ) / div )*mul / 360.0; //+ float(div)/360.0 ;
            part.g = float( int( part.g*360.0 ) / div )*mul / 360.0*1.1; //+ float(div)/360.0 ;
            part.b = float( int( part.b*360.0 ) / div )*mul / 360.0*1.6; //+ float(div)/360.0 ;

        }
        else if( InBound(pCoord.x, left+ratio8*drawingWidth,left+ratio3*drawingWidth) && InBound( pCoord.y,top+ratio6*textureHeight, top+ratio9*drawingHeight))
        {

            float x = 2.0 *1.06*(fsTexture.x-textureRect.x) / textureWidth - 1.0 ;
            float y = 2.0 *1.06*(fsTexture.y-textureRect.y) / textureHeight - 1.0 ;

            //        float r = sqrt(x*x + y*y);
            //        float phi = atan(y,x);//equivalent to atan2
            //
            //        float t = 3.1415/4.0;//mod( float( timer ), 30000.0 ) / 1000.0; //0 - 30 seconds
            //        float fac = abs( sin( t ) )*2.0 + .125;//+1.5;/// 2.0 + 1.5;
            //        r = pow( r, fac );//fac );//magnifier
            //
            //        x = r * cos( phi );
            //        y = r * sin( phi );

            float i = (x + 1.0 )*textureWidth*.5+textureRect.x ;
            float j = (y + 1.0 )*textureHeight*.5+textureRect.y ;
            i  = InBound(i, textureRect.x, textureRect.x+texWidth)?i:fsTexture.x;
            j = InBound(j, textureRect.y , textureRect.y+texHeight)?j:fsTexture.y;
            part = getColor( inputTex, vec2(i,j)/input.texSize );
#ifdef PRE_MULT
            divideAlpha(part);
#endif
            part.rgb /= u.nitsScale;

            int div = 50;
            float mul = float(div);
            part.r = float( int( part.r*360.0 ) / div )*mul / 360.0*.9; //+ float(div)/360.0 ;
            part.g = float( int( part.g*360.0 ) / div )*mul / 360.0*1.5; //+ float(div)/360.0 ;
            part.b = float( int( part.b*360.0 ) / div )*mul / 360.0*.9; //+ float(div)/360.0 ;

        }
        else if( InBound(pCoord.x, left+ratio10*drawingWidth, left+ratio8*drawingWidth) && InBound( pCoord.y,top+ratio6*drawingHeight, top+ratio1*drawingHeight))
        {

            float x = 2.0 * (fsTexture.x*1.01-textureRect.x*1.01) / textureWidth - 1.0 ;
            float y = 2.0 * (fsTexture.y*1.01-textureRect.y*1.01) / textureHeight - 1.0 ;

            //        float r = sqrt(x*x + y*y);
            //        float phi = atan(y,x);//equivalent to atan2
            //
            //        float t = 3.1415/4.0;//mod( float( timer ), 30000.0 ) / 1000.0; //0 - 30 seconds
            //        float fac = abs( sin( t ) )*2.0 + .125;//+1.5;/// 2.0 + 1.5;
            //        r = pow( r, fac );//fac );//magnifier
            //
            //        x = r * cos( phi );
            //        y = r * sin( phi );

            float i = (x + 1.0 )*textureWidth*.5+textureRect.x ;
            float j = (y + 1.0 )*textureHeight*.5+textureRect.y ;
            i  = InBound(i, textureRect.x , textureRect.x+texWidth)?i:fsTexture.x;
            j = InBound(j, textureRect.y , textureRect.y+texHeight)?j:fsTexture.y;
            part =  getColor( inputTex, vec2(i,j)/input.texSize );
#ifdef PRE_MULT
            divideAlpha(part);
#endif
            part.rgb /= u.nitsScale;

            int div = 45;
            float mul = float(div);
            part.r = float( int( part.r*360.0 ) / div )*mul / 360.0*1.2; //+ float(div)/360.0 ;
            part.g = float( int( part.g*360.0 ) / div )*mul / 360.0*.9; //+ float(div)/360.0 ;
            part.b = float( int( part.b*360.0 ) / div )*mul / 360.0*1.1; //+ float(div)/360.0 ;

        }
        else if( InBound(pCoord.x, left+ratio5*drawingWidth,left+ratio10*drawingWidth) && InBound( pCoord.y,top+ratio11*drawingHeight, top+ratio1*drawingHeight))
        {

            float x = 2.0 * (fsTexture.x*1.03-textureRect.x*1.03) / textureWidth - 1.0 ;
            float y = 2.0 * (fsTexture.y*1.03)-textureRect.y*1.03 / textureHeight - 1.0 ;

            //        float r = sqrt(x*x + y*y);
            //        float phi = atan(y,x);//equivalent to atan2
            //
            //        float t = 3.1415/4.0;//mod( float( timer ), 30000.0 ) / 1000.0; //0 - 30 seconds
            //        float fac = abs( sin( t ) )*2.0 + .125;//+1.5;/// 2.0 + 1.5;
            //        r = pow( r, fac );//fac );//magnifier
            //
            //        x = r * cos( phi );
            //        y = r * sin( phi );

            float i = (x + 1.0 )*textureWidth*.5+textureRect.x;
            float j = (y + 1.0 )*textureHeight*.5+textureRect.y;
            i  = InBound(i, textureRect.x , textureRect.x +texWidth)?i:fsTexture.x;
            j = InBound(j, textureRect.y , textureRect.y+texHeight)?j:fsTexture.y;
            part =  getColor( inputTex, vec2(i,j)/input.texSize );
#ifdef PRE_MULT
            divideAlpha(part);
#endif
            part.rgb /= u.nitsScale;

            int div = 67;
            float mul = float(div);
            part.r = float( int( part.r*360.0 ) / div )*mul / 360.0; //+ float(div)/360.0 ;
            part.g = float( int( part.g*360.0 ) / div )*mul / 360.0; //+ float(div)/360.0 ;
            part.b = float( int( part.b*360.0 ) / div )*mul / 360.0; //+ float(div)/360.0 ;


        }
        else if( InBound(pCoord.x, left+ratio8*drawingWidth, left+ratio1*drawingWidth) && InBound( pCoord.y,top+ratio11*drawingHeight,top+ratio1*drawingHeight))
        {

            float x = 2.0 * (fsTexture.x*.98-textureRect.x*.98) / textureWidth - 1.0 ;
            float y = 2.0 * (fsTexture.y*.98-textureRect.y*.98) / textureHeight - 1.0 ;

            //        float r = sqrt(x*x + y*y);
            //        float phi = atan(y,x);//equivalent to atan2
            //
            //        float t = 3.1415/4.0;//mod( float( timer ), 30000.0 ) / 1000.0; //0 - 30 seconds
            //        float fac = abs( sin( t ) )*2.0 + .125;//+1.5;/// 2.0 + 1.5;
            //        r = pow( r, fac );//fac );//magnifier
            //
            //        x = r * cos( phi );
            //        y = r * sin( phi );

            float i = (x + 1.0 )*textureWidth*.5+textureRect.x;
            float j = (y + 1.0 )*textureHeight*.5+textureRect.y;
            i  = InBound(i , textureRect.x , textureRect.x+texWidth)?i:fsTexture.x;
            j = InBound(j, textureRect.y , textureRect.y+texHeight)?j:fsTexture.y;
            part =  getColor( inputTex, vec2(i,j) /input.texSize);
#ifdef PRE_MULT
            divideAlpha(part);
#endif
            part.rgb /= u.nitsScale;
            
            int div = 40;
            float mul = float(div);
            part.r = float( int( part.r*360.0 ) / div )*mul / 360.0*1.1; //+ float(div)/360.0 ;
            part.g = float( int( part.g*360.0 ) / div )*mul / 360.0; //+ float(div)/360.0 ;
            part.b = float( int( part.b*360.0 ) / div )*mul / 360.0; //+ float(div)/360.0 ;

        }
        else if( InBound(pCoord.x, left+ratio4*drawingWidth, left+ratio10*drawingWidth) && InBound( pCoord.y,top+ratio6*drawingHeight, top+ratio11*drawingHeight))
        {

            float x = 2.0 * (fsTexture.x*1.1-textureRect.x*1.1) / textureWidth - 1.0 ;
            float y = 2.0 * (fsTexture.y*1.1-textureRect.y*1.1) / textureHeight - 1.0 ;

            //        float r = sqrt(x*x + y*y);
            //        float phi = atan(y,x);//equivalent to atan2
            //
            //        float t = 3.1415/4.0;//mod( float( timer ), 30000.0 ) / 1000.0; //0 - 30 seconds
            //        float fac = abs( sin( t ) )*2.0 + .125;//+1.5;/// 2.0 + 1.5;
            //        r = pow( r, fac );//fac );//magnifier
            //
            //        x = r * cos( phi );
            //        y = r * sin( phi );

            float i = (x + 1.0 )*textureWidth*.5+textureRect.x;
            float j = (y + 1.0 )*textureHeight*.5+textureRect.y;
            i  = InBound(i , textureRect.x, textureRect.x+texWidth)?i:fsTexture.x;
            j = InBound(j, textureRect.y , textureRect.y+texHeight)?j:fsTexture.y;
            part = getColor( inputTex, vec2(i,j)/input.texSize );
#ifdef PRE_MULT
            divideAlpha(part);
#endif
            part.rgb /= u.nitsScale;

            int div = 50;
            float mul = float(div);
            part.r = float( int( part.r*360.0 ) / div )*mul / 360.0; //+ float(div)/360.0 ;
            part.g = float( int( part.g*360.0 ) / div )*mul / 360.0*1.1; //+ float(div)/360.0 ;
            part.b = float( int( part.b*360.0 ) / div )*mul / 360.0*1.9; //+ float(div)/360.0 ;

        }
        else if( InBound(pCoord.x, left, left+ratio12*drawingWidth) && InBound( pCoord.y,top+ratio6*drawingHeight, top+ratio11*drawingHeight))
        {
            float x = textureHeight+textureRect.y -fsTexture.y;
            float y = textureWidth/2.0-(fsTexture.x-textureRect.x)+textureRect.x;

            x = InBound(x, textureRect.x, textureRect.x+texWidth)?x:fsTexture.x ;
            y = InBound(y, textureRect.y, textureRect.y+texHeight)?y:fsTexture.y;

            part =  getColor( inputTex, vec2( x,y)/input.texSize);
#ifdef PRE_MULT
            divideAlpha(part);
#endif
            part.rgb /= u.nitsScale;

            int div = 60;
            float mul = float(div);
            part.r = float( int( part.r*360.0 ) / div )*mul / 360.0; //+ float(div)/360.0 ;
            part.g = float( int( part.g*360.0 ) / div )*mul / 360.0*1.5; //+ float(div)/360.0 ;
            part.b = float( int( part.b*360.0 ) / div )*mul / 360.0; //+ float(div)/360.0 ;

        }
        else if( InBound(pCoord.x, left, left+ratio13*drawingWidth) && InBound( pCoord.y,top+ratio11*drawingHeight, top+ratio1*drawingHeight))
        {
            float x = textureWidth/2.0-(fsTexture.x-textureRect.x)+textureRect.x;
            float y = textureHeight/2.0-(textureHeight+textureRect.y-fsTexture.y);
            x = InBound(x, textureRect.x, textureRect.x+texWidth)?x:fsTexture.x;
            y = InBound(y, textureRect.y, textureRect.y+texHeight)?y:fsTexture.y;

            part =  getColor( inputTex, vec2( x , y)/input.texSize );
#ifdef PRE_MULT
            divideAlpha(part);
#endif
            part.rgb /= u.nitsScale;

            int div = 90;
            float mul = float(div);
            part.r = float( int( part.r*360.0 ) / div )*mul / 360.0; //+ float(div)/360.0 ;
            part.g = float( int( part.g*360.0 ) / div )*mul / 360.0*1.5; //+ float(div)/360.0 ;
            part.b = float( int( part.b*360.0 ) / div )*mul / 360.0; //+ float(div)/360.0 ;

        }
        else
        {
            float x = fsTexture.x*1.03;
            float y = fsTexture.y*1.03;
            x = InBound(x, textureRect.x, textureRect.x+texWidth)?x:fsTexture.x;
            y = InBound(y, textureRect.y, textureRect.y+texHeight)?y:fsTexture.y;
            part = getColor( inputTex, vec2( x,y)/input.texSize );
#ifdef PRE_MULT
            divideAlpha(part);
#endif
            part.rgb /= u.nitsScale;

            int div = 40;
            float mul = float(div);
            part.r = float( int( part.r*360.0 ) / div )*mul / 360.0*.7; //+ float(div)/360.0 ;
            part.g = float( int( part.g*360.0 ) / div )*mul / 360.0*1.8; //+ float(div)/360.0 ;
            part.b = float( int( part.b*360.0 ) / div )*mul / 360.0*1.3; //+ float(div)/360.0 ;
        }
    }
    float4 outColor;
    outColor.a=texel.a;

    outColor.rgb=part.rgb;

    float blendValue=u.blendValue;
#ifdef USE_MASK
    blendValue*=getColor(inputTexMask,input.texMask).a;
#endif
    outColor.rgb = mix(texel.rgb, outColor.rgb * u.nitsScale, blendValue);
#ifdef PRE_MULT
    multiplyAlpha(outColor);
#endif
    return outColor;
}

