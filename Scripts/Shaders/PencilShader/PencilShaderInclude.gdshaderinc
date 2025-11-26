//the pencil texture to blend with
uniform sampler2D u_patternTexture : repeat_enable;

vec4 pencil_fragment(sampler2D texture, vec2 uv, float frame)
{
	//offset the pattern
	vec2 pattern_uv;
	pattern_uv = uv + sin(frame);
	
	vec4 base_color = texture(texture, uv);
	//UV * X scales the texture, texture(..) * X brightens the texture
	vec4 pattern_color = texture(u_patternTexture,pattern_uv * 2.0) * 0.95;
	
	
	return base_color / pattern_color;

}