uniform sampler2D SCREEN_TEXTURE : hint_screen_texture, repeat_disable, filter_nearest;
uniform sampler2D u_patternTexture : repeat_enable;

vec2 rotateUV(vec2 uv, vec2 pivot, float angle)
{
	mat2 rotation = mat2( vec2(sin(angle), -cos(angle)),
						vec2(cos(angle), sin(angle)));
	
	uv -= pivot;
	uv = uv * rotation;
	uv += pivot;
	
	return uv;
}

vec4 pencil_fragment(sampler2D texture, vec2 uv, float frame)
{
	vec2 pattern_uv;
	pattern_uv = uv + sin(frame);
	//pattern_uv = rotateUV(pattern_uv, vec2(0.5), sign(sin(TIME)));
	vec4 base_color = texture(texture, uv);
	vec4 pattern_color = texture(u_patternTexture,pattern_uv * 2.0) * 0.95;
	
	return base_color / pattern_color;

}

