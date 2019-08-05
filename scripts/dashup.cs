﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashup : abilities {
	/*public float cooldown;
	public float cooleddown = 2.0f;*/
	public float boost = 1.0f;
	public float boostup = 1.0f;
	/*
	public float startdashtime;
	public float dashtime = 2.0f;*/
	public float gravityafterdash = 5.0f;

	//public player1controllerwithjump p;

	/*public bool abled = true;
	private bool checkd = false;*/
	// Use this for initialization
	public Rigidbody2D rb;
	public crouch c;
	public Animator anim;
	public player1controllerwithjump p;

	void OnDisable(){
		if (cooldown <= 0f) {
			cooldown = cooleddown;
			checkd = true;
		}
		starttime = 0f;
		this.rb.gravityScale = gravityafterdash;
		playshort ();
	}

	void OnEnable(){
		//pppp = GameObject.FindGameObjectWithTag ("Player");
		if (GameMaster.pppppp == null) {
			p = GameObject.FindGameObjectWithTag ("Player").GetComponent<player1controllerwithjump> ();
			rb = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
			c = GameObject.FindGameObjectWithTag ("Player").GetComponent<crouch> ();
			anim = GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ();
		} else {
			p = GameMaster.pppppp.GetComponent<player1controllerwithjump> ();
			rb = GameMaster.pppppp.GetComponent<Rigidbody2D> ();
			c = GameMaster.pppppp.GetComponent<crouch> ();
			anim = GameMaster.pppppp.GetComponent<Animator> ();
		}
		starttime = 0f;
	}
	void Start () {
		//p = GetComponent<player1controllerwithjump> ();
	}

	// Update is called once per frame
	void Update () {

		//if (!stop) {
		aaa = true;
		if (Input.GetButton ("Move1") &&Input.GetButton ("Jump")&&Input.GetButton ("Horizontal") && Input.GetButtonDown ("Fire1") && abled && !c.iscrouch&&!this.GetComponent<dash>().ishappening) {

			starttime = duration;
			abled = false;
			anim.Play ("dashup");
			ishappening = true;
		} 
		if (cooldown > 0f) {
			cooldown -= Time.deltaTime;
			if (cooldown <= 0f) {
				abled = true;
			}
		}
		if (starttime > 0f) {
			checkd = false;
			if (p.facingRight) {
				this.rb.velocity = new Vector2 (boost, boostup);
				p.enabled = false;
				this.rb.gravityScale = 0;
			} else {
				this.rb.velocity = new Vector2 (-boost, boostup);
				p.enabled = false;
				this.rb.gravityScale = 0;
			}
			starttime -= Time.deltaTime;
		} 
		if (starttime < 0f && !checkd) {
			ishappening = false;
			anim.Play ("idle");
			if (cooldown <= 0f) {
				cooldown = cooleddown;
				checkd = true;
			}
			p.enabled = true;
			this.rb.gravityScale = gravityafterdash;


		}
		/*} else {
			if (cooldown <= 0f) {
				cooldown = cooleddown;
				checkd = true;
			}
			starttime = 0f;
			playshort ();

			//p.enabled = true;
			this.rb.gravityScale = gravityafterdash;
		}*/
	}
	void playshort(){
		if (aaa) {
			//anim.Play ("idle");
		}
		aaa = false;
	}
}
