#version 440

uniform sampler2D textureSampler;

layout(location = 0) in vec2 fUV;

layout(location = 0) out vec4 color;

void main()
{
	color = texture(textureSampler, fUV);
}