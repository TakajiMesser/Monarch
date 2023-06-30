#version 440

uniform sampler2D textureSampler;

in vec2 fUV;
out vec4 color;

void main()
{
	color = texture(textureSampler, fUV);
}