#version 440

uniform sampler2D textureSampler;

layout(location = 0) in vec2 fUV;
layout(location = 1) in vec4 fTextColor;

layout(location = 0) out vec4 finalColor;

void main()
{
	vec4 textureColor = texture(textureSampler, fUV);

	if (textureColor.w == 1.0 && (textureColor.x == 1.0 && textureColor.y == 1.0 && textureColor.z == 1.0))
	{
		finalColor = fTextColor;
	}
	else
	{
		discard;
	}
}